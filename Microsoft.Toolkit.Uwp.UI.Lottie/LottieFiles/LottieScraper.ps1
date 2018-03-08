
function GetTitleAndLink($card)
{
  $downloadLink =  $card.getElementsByTagName('a') | ?{$_.title -eq 'Download Animation'} | %{$_.href} | %{$_ -replace 'about:','https://www.lottiefiles.com'}
  $title = $card.getElementsByClassName('item-title') | %{$_.innerText}
  $jsonLink = $card | %{$_.getElementsByClassName('show_preview')} | %{$_.getAttribute('data-filename')} 

  # Get the filename as stored on the download server.
  write-host "Creating request for $downloadLink"
  $request = [System.Net.WebRequest]::Create($downloadLink)
  $response = $request.GetResponse()
  $filename = $response.Headers['Content-Disposition'] -replace '.*filename=\"(.*)\"','$1'
  $response.Dispose()

  write-host $filename
  "{ title:`"$title`", download:`"$downloadLink`", json:`"$jsonLink`", filename:`"$filename`" }"
}

function GetCards($pageNumber)
{
  $url = "http://lottiefiles.com/?page=$pageNumber"
  write-host $url 
  $page = invoke-webrequest $url
  write-host 'Page loaded'
  $page.ParsedHtml.documentElement.getElementsByClassName('card')
}

'{ "entries":[ '

(1..51 | %{ GetCards($_) | %{GetTitleAndLink($_)} }) -join ','

']}'
