﻿using System;
using WinCompData.Sn;
using WinCompData.Wui;

namespace WinCompData.CodeGen
{
    /// <summary>
    /// Stringifiers for C++ syntax.
    /// </summary>
    sealed class CppStringifier : InstantiatorGeneratorBase.IStringifier
    {
        string InstantiatorGeneratorBase.IStringifier.Deref => "->";

        string InstantiatorGeneratorBase.IStringifier.MemberSelect => ".";

        string InstantiatorGeneratorBase.IStringifier.ScopeResolve => "::";

        string InstantiatorGeneratorBase.IStringifier.Var => "auto";

        string InstantiatorGeneratorBase.IStringifier.New => "ref new";

        string InstantiatorGeneratorBase.IStringifier.Null => "nullptr";

        string InstantiatorGeneratorBase.IStringifier.Bool(bool value) => value ? "true" : "false";

        string InstantiatorGeneratorBase.IStringifier.Color(Color value) => $"Color::FromArgb({Hex(value.A)}, {Hex(value.R)}, {Hex(value.G)}, {Hex(value.B)})";

        string InstantiatorGeneratorBase.IStringifier.Float(float value) => Float(value);

        string InstantiatorGeneratorBase.IStringifier.Int(int value) => value.ToString();

        string InstantiatorGeneratorBase.IStringifier.Matrix3x2(Matrix3x2 value)
        {
            return $"*(ref new float3x2({Float(value.M11)}, {Float(value.M12)},{Float(value.M21)}, {Float(value.M22)}, {Float(value.M31)}, {Float(value.M32)}))";
        }

        string InstantiatorGeneratorBase.IStringifier.String(string value) => $"\"{value}\"";

        string InstantiatorGeneratorBase.IStringifier.TimeSpan(TimeSpan value) => $"{value.Ticks}L";

        string InstantiatorGeneratorBase.IStringifier.Vector2(Vector2 value) => $"*(ref new float2({ Float(value.X) }, { Float(value.Y)}))";

        string InstantiatorGeneratorBase.IStringifier.Vector3(Vector3 value) => $"(ref new float3({ Float(value.X) }, { Float(value.Y)}, {Float(value.Z)}))";

        static string Float(float value)
        {
            if (Math.Floor(value) == value)
            {
                // Round numbers don't need decimal places or the F suffix.
                return value.ToString("0");
            }
            else
            {
                return value == 0 ? "0" : (value.ToString("0.######################################") + "F");
            }
        }

        static string Hex(int value) => $"0x{value.ToString("X2")}";
    }
}
