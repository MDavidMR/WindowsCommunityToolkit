# Parses the output of the LottieGen tool and produces a hash containing info
# about what happened.
#
# Examples:
#  Find all the lottie files that have an error with 'ml2' in it:
#    type .\log.txt | .\ProcessLog.ps1 | ?{$_.errors} | ?{$_.errors | ?{$_ -match 'ml2'} }
#
#  Find the names of all the lottie files that use expressions:
#    type .\log.txt | .\ProcessLog.ps1 | ?{$_.errors} | ?{$_.errors | ?{$_ -match 'LP0015'} } | %{$_.input}
#
#  Find the version numbers used by lottie files:
#    type .\log.txt | .\ProcessLog.ps1 | ?{$_.version} | %{$_.version} | sort -uniq
#
#  Find the lottie files that use version 5.2.1:
#    type .\log.txt | .\ProcessLog.ps1 | ?{$_.version} | %{$_.version -eq '5.2.1'}
#

Begin { 
    $instance=@{} 
    $isInLottieInfoSection = $false

    function YieldInstance() {
        # Output the info collected for the current instance and
        # reset state
        if ($instance.Count)
        {
          # Output a copy of the instance.
          $instance.Clone()
        }
        # Reset state ready for the next set of lines
        $instance.Clear()
        $instance['errors']=@()
        $isInLottieInfoSection = $false
    }

    function AddError($error) {
      if (-not $instance['errors'])
      {
          $instance['errors']=@()
      }
      $instance['errors']+=$error.Trim()
    }
  }

Process {
    if (select-string -input $_ 'Lottie for Windows Code Generator') {
      # Yield the info from the previous input.
      YieldInstance
    } else {
       if ($_)
       {
          switch -regex ($_)
          {
            # NOTE: these are evaluated in order, so a single value may match
            #       multiple cases.
            '=== .* ===' { $isInLottieInfoSection = $false }
            '=== Lottie info ===' { $isInLottieInfoSection = $true }
            '^Reading Lottie file:' { $instance['input']=$_ -replace 'Reading Lottie file: ','' }
            '^C# code' { $instance['output']=$_ -replace '.* written to ','' }
            '^.*: error L' { $instance['errors']+=($_ -replace '^.*: error ','').Trim() }
            'BodyMovin Version ' {$instance['version']=($_ -replace '^.* BodyMovin Version ','').Trim()}
            '^Error:' {AddError $_}
          }
          # Parse the Lottie Info section
          if ($isInLottieInfoSection)
          {
              switch -regex ($_)
              {
                  'Duration' { $instance['durationSeconds'] = [double]($_ -replace '^.*Duration\W*','' -replace '\W*seconds','') }
                  'Masks ' { $instance['masks'] = [int]($_ -replace '\D*','') }
                  'MaskAdditive' { $instance['maskAdditive'] = [int]($_ -replace '\D*','') }
                  'MaskDarken' { $instance['maskDarken'] = [int]($_ -replace '\D*','') }
                  'MaskDifference' { $instance['maskDifference'] = [int]($_ -replace '\D*','') }
                  'MaskIntersect' { $instance['maskIntersect'] = [int]($_ -replace '\D*','') }
                  'MaskLighten' { $instance['maskLighten'] = [int]($_ -replace '\D*','') }
                  'MaskSubtract' { $instance['maskSubtract'] = [int]($_ -replace '\D*','') }
                  'Precomps' { $instance['precomps'] = [int]($_ -replace '\D*','') }
                  'Masks' { $instance['masks'] = [int]($_ -replace '\D*','') }
              }
          }

       }
    }
  }

End { YieldInstance }
