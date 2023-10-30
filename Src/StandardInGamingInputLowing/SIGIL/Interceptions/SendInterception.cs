using System;
using System.Runtime.InteropServices;

namespace Interceptions
{
    public class Valuechanges
    {
        public static double[] _valuechange = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public static double[] _ValueChange = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
        public double this[int index]
        {
            get { return _ValueChange[index]; }
            set
            {
                if (_valuechange[index] != value)
                    _ValueChange[index] = value - _valuechange[index];
                else
                    _ValueChange[index] = 0;
                _valuechange[index] = value;
            }
        }
    }
    public class SendInterception
    {
        [DllImport("user32.dll")]
        public static extern void SetPhysicalCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        public static extern void SetCaretPos(int X, int Y);
        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int X, int Y);
        public static Valuechanges ValueChange = new Valuechanges();
        public static void UnLoadKM(Input input, int keyboard_1_id, int mouse_1_id)
        {
            SetKM(0, 0, input, keyboard_1_id, mouse_1_id, 0, 0, 0, 0, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
        }
        public static void SetKM(double MouseDesktopX, double MouseDesktopY, Input input, int keyboard_id, int mouse_id, double deltaX, double deltaY, double x, double y, bool SendLeftClick, bool SendRightClick, bool SendMiddleClick, bool SendWheelUp, bool SendWheelDown, bool SendCANCEL, bool SendBACK, bool SendTAB, bool SendCLEAR, bool SendRETURN, bool SendSHIFT, bool SendCONTROL, bool SendMENU, bool SendCAPITAL, bool SendESCAPE, bool SendSPACE, bool SendPRIOR, bool SendNEXT, bool SendEND, bool SendHOME, bool SendLEFT, bool SendUP, bool SendRIGHT, bool SendDOWN, bool SendSNAPSHOT, bool SendINSERT, bool SendNUMPADDEL, bool SendNUMPADINSERT, bool SendHELP, bool SendAPOSTROPHE, bool SendBACKSPACE, bool SendPAGEDOWN, bool SendPAGEUP, bool SendFIN, bool SendMOUSE, bool SendA, bool SendB, bool SendC, bool SendD, bool SendE, bool SendF, bool SendG, bool SendH, bool SendI, bool SendJ, bool SendK, bool SendL, bool SendM, bool SendN, bool SendO, bool SendP, bool SendQ, bool SendR, bool SendS, bool SendT, bool SendU, bool SendV, bool SendW, bool SendX, bool SendY, bool SendZ, bool SendLWIN, bool SendRWIN, bool SendAPPS, bool SendDELETE, bool SendNUMPAD0, bool SendNUMPAD1, bool SendNUMPAD2, bool SendNUMPAD3, bool SendNUMPAD4, bool SendNUMPAD5, bool SendNUMPAD6, bool SendNUMPAD7, bool SendNUMPAD8, bool SendNUMPAD9, bool SendMULTIPLY, bool SendADD, bool SendSUBTRACT, bool SendDECIMAL, bool SendPRINTSCREEN, bool SendDIVIDE, bool SendF1, bool SendF2, bool SendF3, bool SendF4, bool SendF5, bool SendF6, bool SendF7, bool SendF8, bool SendF9, bool SendF10, bool SendF11, bool SendF12, bool SendNUMLOCK, bool SendSCROLLLOCK, bool SendLEFTSHIFT, bool SendRIGHTSHIFT, bool SendLEFTCONTROL, bool SendRIGHTCONTROL, bool SendLEFTALT, bool SendRIGHTALT, bool SendBROWSER_BACK, bool SendBROWSER_FORWARD, bool SendBROWSER_REFRESH, bool SendBROWSER_STOP, bool SendBROWSER_SEARCH, bool SendBROWSER_FAVORITES, bool SendBROWSER_HOME, bool SendVOLUME_MUTE, bool SendVOLUME_DOWN, bool SendVOLUME_UP, bool SendMEDIA_NEXT_TRACK, bool SendMEDIA_PREV_TRACK, bool SendMEDIA_STOP, bool SendMEDIA_PLAY_PAUSE, bool SendLAUNCH_MAIL, bool SendLAUNCH_MEDIA_SELECT, bool SendLAUNCH_APP1, bool SendLAUNCH_APP2, bool SendOEM_1, bool SendOEM_PLUS, bool SendOEM_COMMA, bool SendOEM_MINUS, bool SendOEM_PERIOD, bool SendOEM_2, bool SendOEM_3, bool SendOEM_4, bool SendOEM_5, bool SendOEM_6, bool SendOEM_7, bool SendOEM_8, bool SendOEM_102, bool SendEREOF, bool SendZOOM, bool SendEscape, bool SendOne, bool SendTwo, bool SendThree, bool SendFour, bool SendFive, bool SendSix, bool SendSeven, bool SendEight, bool SendNine, bool SendZero, bool SendDashUnderscore, bool SendPlusEquals, bool SendBackspace, bool SendTab, bool SendOpenBracketBrace, bool SendCloseBracketBrace, bool SendEnter, bool SendControl, bool SendSemicolonColon, bool SendSingleDoubleQuote, bool SendTilde, bool SendLeftShift, bool SendBackslashPipe, bool SendCommaLeftArrow, bool SendPeriodRightArrow, bool SendForwardSlashQuestionMark, bool SendRightShift, bool SendRightAlt, bool SendSpace, bool SendCapsLock, bool SendUp, bool SendDown, bool SendRight, bool SendLeft, bool SendHome, bool SendEnd, bool SendDelete, bool SendPageUp, bool SendPageDown, bool SendInsert, bool SendPrintScreen, bool SendNumLock, bool SendScrollLock, bool SendMenu, bool SendWindowsKey, bool SendNumpadDivide, bool SendNumpadAsterisk, bool SendNumpad7, bool SendNumpad8, bool SendNumpad9, bool SendNumpad4, bool SendNumpad5, bool SendNumpad6, bool SendNumpad1, bool SendNumpad2, bool SendNumpad3, bool SendNumpad0, bool SendNumpadDelete, bool SendNumpadEnter, bool SendNumpadPlus, bool SendNumpadMinus)
        {
            MoveMouseBy(input, (int)deltaX, (int)deltaY, mouse_id);
            MoveMouseTo(input, (int)x, (int)y, mouse_id);
            if (MouseDesktopX != 0f | MouseDesktopY != 0f)
            {
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point((int)(MouseDesktopX), (int)(MouseDesktopY));
                SetPhysicalCursorPos((int)(MouseDesktopX), (int)(MouseDesktopY));
                SetCaretPos((int)(MouseDesktopX), (int)(MouseDesktopY));
                SetCursorPos((int)(MouseDesktopX), (int)(MouseDesktopY));
            }
            ValueChange[1] = SendLeftClick ? 1 : 0;
            if (Valuechanges._ValueChange[1] > 0f)
                mouseclickleft(input, mouse_id);
            if (Valuechanges._ValueChange[1] < 0f)
                mouseclickleftF(input, mouse_id);
            ValueChange[2] = SendRightClick ? 1 : 0;
            if (Valuechanges._ValueChange[2] > 0f)
                mouseclickright(input, mouse_id);
            if (Valuechanges._ValueChange[2] < 0f)
                mouseclickrightF(input, mouse_id);
            ValueChange[3] = SendMiddleClick ? 1 : 0;
            if (Valuechanges._ValueChange[3] > 0f)
                mouseclickmiddle(input, mouse_id);
            if (Valuechanges._ValueChange[3] < 0f)
                mouseclickmiddleF(input, mouse_id);
            ValueChange[4] = SendWheelUp ? 1 : 0;
            if (Valuechanges._ValueChange[4] > 0f)
                mousewheelup(input, mouse_id);
            ValueChange[5] = SendWheelDown ? 1 : 0;
            if (Valuechanges._ValueChange[5] > 0f)
                mousewheeldown(input, mouse_id);
            ValueChange[6] = SendCANCEL ? 1 : 0;
            if (Valuechanges._ValueChange[6] > 0f)
                keyboardkey(input, Keys.CANCEL, keyboard_id);
            if (Valuechanges._ValueChange[6] < 0f)
                keyboardkeyF(input, Keys.CANCEL, keyboard_id);
            ValueChange[7] = SendBACK ? 1 : 0;
            if (Valuechanges._ValueChange[7] > 0f)
                keyboardkey(input, Keys.BACK, keyboard_id);
            if (Valuechanges._ValueChange[7] < 0f)
                keyboardkeyF(input, Keys.BACK, keyboard_id);
            ValueChange[8] = SendTAB ? 1 : 0;
            if (Valuechanges._ValueChange[8] > 0f)
                keyboardkey(input, Keys.TAB, keyboard_id);
            if (Valuechanges._ValueChange[8] < 0f)
                keyboardkeyF(input, Keys.TAB, keyboard_id);
            ValueChange[9] = SendCLEAR ? 1 : 0;
            if (Valuechanges._ValueChange[9] > 0f)
                keyboardkey(input, Keys.CLEAR, keyboard_id);
            if (Valuechanges._ValueChange[9] < 0f)
                keyboardkeyF(input, Keys.CLEAR, keyboard_id);
            ValueChange[10] = SendRETURN ? 1 : 0;
            if (Valuechanges._ValueChange[10] > 0f)
                keyboardkey(input, Keys.RETURN, keyboard_id);
            if (Valuechanges._ValueChange[10] < 0f)
                keyboardkeyF(input, Keys.RETURN, keyboard_id);
            ValueChange[11] = SendSHIFT ? 1 : 0;
            if (Valuechanges._ValueChange[11] > 0f)
                keyboardkey(input, Keys.SHIFT, keyboard_id);
            if (Valuechanges._ValueChange[11] < 0f)
                keyboardkeyF(input, Keys.SHIFT, keyboard_id);
            ValueChange[12] = SendCONTROL ? 1 : 0;
            if (Valuechanges._ValueChange[12] > 0f)
                keyboardkey(input, Keys.CONTROL, keyboard_id);
            if (Valuechanges._ValueChange[12] < 0f)
                keyboardkeyF(input, Keys.CONTROL, keyboard_id);
            ValueChange[13] = SendMENU ? 1 : 0;
            if (Valuechanges._ValueChange[13] > 0f)
                keyboardkey(input, Keys.MENU, keyboard_id);
            if (Valuechanges._ValueChange[13] < 0f)
                keyboardkeyF(input, Keys.MENU, keyboard_id);
            ValueChange[14] = SendCAPITAL ? 1 : 0;
            if (Valuechanges._ValueChange[14] > 0f)
                keyboardkey(input, Keys.CAPITAL, keyboard_id);
            if (Valuechanges._ValueChange[14] < 0f)
                keyboardkeyF(input, Keys.CAPITAL, keyboard_id);
            ValueChange[15] = SendESCAPE ? 1 : 0;
            if (Valuechanges._ValueChange[15] > 0f)
                keyboardkey(input, Keys.ESCAPE, keyboard_id);
            if (Valuechanges._ValueChange[15] < 0f)
                keyboardkeyF(input, Keys.ESCAPE, keyboard_id);
            ValueChange[16] = SendSPACE ? 1 : 0;
            if (Valuechanges._ValueChange[16] > 0f)
                keyboardkey(input, Keys.SPACE, keyboard_id);
            if (Valuechanges._ValueChange[16] < 0f)
                keyboardkeyF(input, Keys.SPACE, keyboard_id);
            ValueChange[17] = SendPRIOR ? 1 : 0;
            if (Valuechanges._ValueChange[17] > 0f)
                keyboardkey(input, Keys.PRIOR, keyboard_id);
            if (Valuechanges._ValueChange[17] < 0f)
                keyboardkeyF(input, Keys.PRIOR, keyboard_id);
            ValueChange[18] = SendNEXT ? 1 : 0;
            if (Valuechanges._ValueChange[18] > 0f)
                keyboardkey(input, Keys.NEXT, keyboard_id);
            if (Valuechanges._ValueChange[18] < 0f)
                keyboardkeyF(input, Keys.NEXT, keyboard_id);
            ValueChange[19] = SendEND ? 1 : 0;
            if (Valuechanges._ValueChange[19] > 0f)
                keyboardkey(input, Keys.END, keyboard_id);
            if (Valuechanges._ValueChange[19] < 0f)
                keyboardkeyF(input, Keys.END, keyboard_id);
            ValueChange[20] = SendHOME ? 1 : 0;
            if (Valuechanges._ValueChange[20] > 0f)
                keyboardkey(input, Keys.HOME, keyboard_id);
            if (Valuechanges._ValueChange[20] < 0f)
                keyboardkeyF(input, Keys.HOME, keyboard_id);
            ValueChange[21] = SendLEFT ? 1 : 0;
            if (Valuechanges._ValueChange[21] > 0f)
                keyboardkey(input, Keys.LEFT, keyboard_id);
            if (Valuechanges._ValueChange[21] < 0f)
                keyboardkeyF(input, Keys.LEFT, keyboard_id);
            ValueChange[22] = SendUP ? 1 : 0;
            if (Valuechanges._ValueChange[22] > 0f)
                keyboardkey(input, Keys.UP, keyboard_id);
            if (Valuechanges._ValueChange[22] < 0f)
                keyboardkeyF(input, Keys.UP, keyboard_id);
            ValueChange[23] = SendRIGHT ? 1 : 0;
            if (Valuechanges._ValueChange[23] > 0f)
                keyboardkey(input, Keys.RIGHT, keyboard_id);
            if (Valuechanges._ValueChange[23] < 0f)
                keyboardkeyF(input, Keys.RIGHT, keyboard_id);
            ValueChange[24] = SendDOWN ? 1 : 0;
            if (Valuechanges._ValueChange[24] > 0f)
                keyboardkey(input, Keys.DOWN, keyboard_id);
            if (Valuechanges._ValueChange[24] < 0f)
                keyboardkeyF(input, Keys.DOWN, keyboard_id);
            ValueChange[25] = SendSNAPSHOT ? 1 : 0;
            if (Valuechanges._ValueChange[25] > 0f)
                keyboardkey(input, Keys.SNAPSHOT, keyboard_id);
            if (Valuechanges._ValueChange[25] < 0f)
                keyboardkeyF(input, Keys.SNAPSHOT, keyboard_id);
            ValueChange[26] = SendINSERT ? 1 : 0;
            if (Valuechanges._ValueChange[26] > 0f)
                keyboardkey(input, Keys.INSERT, keyboard_id);
            if (Valuechanges._ValueChange[26] < 0f)
                keyboardkeyF(input, Keys.INSERT, keyboard_id);
            ValueChange[27] = SendNUMPADDEL ? 1 : 0;
            if (Valuechanges._ValueChange[27] > 0f)
                keyboardkey(input, Keys.NUMPADDEL, keyboard_id);
            if (Valuechanges._ValueChange[27] < 0f)
                keyboardkeyF(input, Keys.NUMPADDEL, keyboard_id);
            ValueChange[28] = SendNUMPADINSERT ? 1 : 0;
            if (Valuechanges._ValueChange[28] > 0f)
                keyboardkey(input, Keys.NUMPADINSERT, keyboard_id);
            if (Valuechanges._ValueChange[28] < 0f)
                keyboardkeyF(input, Keys.NUMPADINSERT, keyboard_id);
            ValueChange[29] = SendHELP ? 1 : 0;
            if (Valuechanges._ValueChange[29] > 0f)
                keyboardkey(input, Keys.HELP, keyboard_id);
            if (Valuechanges._ValueChange[29] < 0f)
                keyboardkeyF(input, Keys.HELP, keyboard_id);
            ValueChange[30] = SendAPOSTROPHE ? 1 : 0;
            if (Valuechanges._ValueChange[30] > 0f)
                keyboardkey(input, Keys.APOSTROPHE, keyboard_id);
            if (Valuechanges._ValueChange[30] < 0f)
                keyboardkeyF(input, Keys.APOSTROPHE, keyboard_id);
            ValueChange[31] = SendBACKSPACE ? 1 : 0;
            if (Valuechanges._ValueChange[31] > 0f)
                keyboardkey(input, Keys.BACKSPACE, keyboard_id);
            if (Valuechanges._ValueChange[31] < 0f)
                keyboardkeyF(input, Keys.BACKSPACE, keyboard_id);
            ValueChange[32] = SendPAGEDOWN ? 1 : 0;
            if (Valuechanges._ValueChange[32] > 0f)
                keyboardkey(input, Keys.PAGEDOWN, keyboard_id);
            if (Valuechanges._ValueChange[32] < 0f)
                keyboardkeyF(input, Keys.PAGEDOWN, keyboard_id);
            ValueChange[33] = SendPAGEUP ? 1 : 0;
            if (Valuechanges._ValueChange[33] > 0f)
                keyboardkey(input, Keys.PAGEUP, keyboard_id);
            if (Valuechanges._ValueChange[33] < 0f)
                keyboardkeyF(input, Keys.PAGEUP, keyboard_id);
            ValueChange[34] = SendFIN ? 1 : 0;
            if (Valuechanges._ValueChange[34] > 0f)
                keyboardkey(input, Keys.FIN, keyboard_id);
            if (Valuechanges._ValueChange[34] < 0f)
                keyboardkeyF(input, Keys.FIN, keyboard_id);
            ValueChange[35] = SendMOUSE ? 1 : 0;
            if (Valuechanges._ValueChange[35] > 0f)
                keyboardkey(input, Keys.MOUSE, keyboard_id);
            if (Valuechanges._ValueChange[35] < 0f)
                keyboardkeyF(input, Keys.MOUSE, keyboard_id);
            ValueChange[36] = SendA ? 1 : 0;
            if (Valuechanges._ValueChange[36] > 0f)
                keyboardkey(input, Keys.A, keyboard_id);
            if (Valuechanges._ValueChange[36] < 0f)
                keyboardkeyF(input, Keys.A, keyboard_id);
            ValueChange[37] = SendB ? 1 : 0;
            if (Valuechanges._ValueChange[37] > 0f)
                keyboardkey(input, Keys.B, keyboard_id);
            if (Valuechanges._ValueChange[37] < 0f)
                keyboardkeyF(input, Keys.B, keyboard_id);
            ValueChange[38] = SendC ? 1 : 0;
            if (Valuechanges._ValueChange[38] > 0f)
                keyboardkey(input, Keys.C, keyboard_id);
            if (Valuechanges._ValueChange[38] < 0f)
                keyboardkeyF(input, Keys.C, keyboard_id);
            ValueChange[39] = SendD ? 1 : 0;
            if (Valuechanges._ValueChange[39] > 0f)
                keyboardkey(input, Keys.D, keyboard_id);
            if (Valuechanges._ValueChange[39] < 0f)
                keyboardkeyF(input, Keys.D, keyboard_id);
            ValueChange[40] = SendE ? 1 : 0;
            if (Valuechanges._ValueChange[40] > 0f)
                keyboardkey(input, Keys.E, keyboard_id);
            if (Valuechanges._ValueChange[40] < 0f)
                keyboardkeyF(input, Keys.E, keyboard_id);
            ValueChange[41] = SendF ? 1 : 0;
            if (Valuechanges._ValueChange[41] > 0f)
                keyboardkey(input, Keys.F, keyboard_id);
            if (Valuechanges._ValueChange[41] < 0f)
                keyboardkeyF(input, Keys.F, keyboard_id);
            ValueChange[42] = SendG ? 1 : 0;
            if (Valuechanges._ValueChange[42] > 0f)
                keyboardkey(input, Keys.G, keyboard_id);
            if (Valuechanges._ValueChange[42] < 0f)
                keyboardkeyF(input, Keys.G, keyboard_id);
            ValueChange[43] = SendH ? 1 : 0;
            if (Valuechanges._ValueChange[43] > 0f)
                keyboardkey(input, Keys.H, keyboard_id);
            if (Valuechanges._ValueChange[43] < 0f)
                keyboardkeyF(input, Keys.H, keyboard_id);
            ValueChange[44] = SendI ? 1 : 0;
            if (Valuechanges._ValueChange[44] > 0f)
                keyboardkey(input, Keys.I, keyboard_id);
            if (Valuechanges._ValueChange[44] < 0f)
                keyboardkeyF(input, Keys.I, keyboard_id);
            ValueChange[45] = SendJ ? 1 : 0;
            if (Valuechanges._ValueChange[45] > 0f)
                keyboardkey(input, Keys.J, keyboard_id);
            if (Valuechanges._ValueChange[45] < 0f)
                keyboardkeyF(input, Keys.J, keyboard_id);
            ValueChange[46] = SendK ? 1 : 0;
            if (Valuechanges._ValueChange[46] > 0f)
                keyboardkey(input, Keys.K, keyboard_id);
            if (Valuechanges._ValueChange[46] < 0f)
                keyboardkeyF(input, Keys.K, keyboard_id);
            ValueChange[47] = SendL ? 1 : 0;
            if (Valuechanges._ValueChange[47] > 0f)
                keyboardkey(input, Keys.L, keyboard_id);
            if (Valuechanges._ValueChange[47] < 0f)
                keyboardkeyF(input, Keys.L, keyboard_id);
            ValueChange[48] = SendM ? 1 : 0;
            if (Valuechanges._ValueChange[48] > 0f)
                keyboardkey(input, Keys.M, keyboard_id);
            if (Valuechanges._ValueChange[48] < 0f)
                keyboardkeyF(input, Keys.M, keyboard_id);
            ValueChange[49] = SendN ? 1 : 0;
            if (Valuechanges._ValueChange[49] > 0f)
                keyboardkey(input, Keys.N, keyboard_id);
            if (Valuechanges._ValueChange[49] < 0f)
                keyboardkeyF(input, Keys.N, keyboard_id);
            ValueChange[50] = SendO ? 1 : 0;
            if (Valuechanges._ValueChange[50] > 0f)
                keyboardkey(input, Keys.O, keyboard_id);
            if (Valuechanges._ValueChange[50] < 0f)
                keyboardkeyF(input, Keys.O, keyboard_id);
            ValueChange[51] = SendP ? 1 : 0;
            if (Valuechanges._ValueChange[51] > 0f)
                keyboardkey(input, Keys.P, keyboard_id);
            if (Valuechanges._ValueChange[51] < 0f)
                keyboardkeyF(input, Keys.P, keyboard_id);
            ValueChange[52] = SendQ ? 1 : 0;
            if (Valuechanges._ValueChange[52] > 0f)
                keyboardkey(input, Keys.Q, keyboard_id);
            if (Valuechanges._ValueChange[52] < 0f)
                keyboardkeyF(input, Keys.Q, keyboard_id);
            ValueChange[53] = SendR ? 1 : 0;
            if (Valuechanges._ValueChange[53] > 0f)
                keyboardkey(input, Keys.R, keyboard_id);
            if (Valuechanges._ValueChange[53] < 0f)
                keyboardkeyF(input, Keys.R, keyboard_id);
            ValueChange[54] = SendS ? 1 : 0;
            if (Valuechanges._ValueChange[54] > 0f)
                keyboardkey(input, Keys.S, keyboard_id);
            if (Valuechanges._ValueChange[54] < 0f)
                keyboardkeyF(input, Keys.S, keyboard_id);
            ValueChange[55] = SendT ? 1 : 0;
            if (Valuechanges._ValueChange[55] > 0f)
                keyboardkey(input, Keys.T, keyboard_id);
            if (Valuechanges._ValueChange[55] < 0f)
                keyboardkeyF(input, Keys.T, keyboard_id);
            ValueChange[56] = SendU ? 1 : 0;
            if (Valuechanges._ValueChange[56] > 0f)
                keyboardkey(input, Keys.U, keyboard_id);
            if (Valuechanges._ValueChange[56] < 0f)
                keyboardkeyF(input, Keys.U, keyboard_id);
            ValueChange[57] = SendV ? 1 : 0;
            if (Valuechanges._ValueChange[57] > 0f)
                keyboardkey(input, Keys.V, keyboard_id);
            if (Valuechanges._ValueChange[57] < 0f)
                keyboardkeyF(input, Keys.V, keyboard_id);
            ValueChange[58] = SendW ? 1 : 0;
            if (Valuechanges._ValueChange[58] > 0f)
                keyboardkey(input, Keys.W, keyboard_id);
            if (Valuechanges._ValueChange[58] < 0f)
                keyboardkeyF(input, Keys.W, keyboard_id);
            ValueChange[59] = SendX ? 1 : 0;
            if (Valuechanges._ValueChange[59] > 0f)
                keyboardkey(input, Keys.X, keyboard_id);
            if (Valuechanges._ValueChange[59] < 0f)
                keyboardkeyF(input, Keys.X, keyboard_id);
            ValueChange[60] = SendY ? 1 : 0;
            if (Valuechanges._ValueChange[60] > 0f)
                keyboardkey(input, Keys.Y, keyboard_id);
            if (Valuechanges._ValueChange[60] < 0f)
                keyboardkeyF(input, Keys.Y, keyboard_id);
            ValueChange[61] = SendZ ? 1 : 0;
            if (Valuechanges._ValueChange[61] > 0f)
                keyboardkey(input, Keys.Z, keyboard_id);
            if (Valuechanges._ValueChange[61] < 0f)
                keyboardkeyF(input, Keys.Z, keyboard_id);
            ValueChange[62] = SendLWIN ? 1 : 0;
            if (Valuechanges._ValueChange[62] > 0f)
                keyboardkey(input, Keys.LWIN, keyboard_id);
            if (Valuechanges._ValueChange[62] < 0f)
                keyboardkeyF(input, Keys.LWIN, keyboard_id);
            ValueChange[63] = SendRWIN ? 1 : 0;
            if (Valuechanges._ValueChange[63] > 0f)
                keyboardkey(input, Keys.RWIN, keyboard_id);
            if (Valuechanges._ValueChange[63] < 0f)
                keyboardkeyF(input, Keys.RWIN, keyboard_id);
            ValueChange[64] = SendAPPS ? 1 : 0;
            if (Valuechanges._ValueChange[64] > 0f)
                keyboardkey(input, Keys.APPS, keyboard_id);
            if (Valuechanges._ValueChange[64] < 0f)
                keyboardkeyF(input, Keys.APPS, keyboard_id);
            ValueChange[65] = SendDELETE ? 1 : 0;
            if (Valuechanges._ValueChange[65] > 0f)
                keyboardkey(input, Keys.DELETE, keyboard_id);
            if (Valuechanges._ValueChange[65] < 0f)
                keyboardkeyF(input, Keys.DELETE, keyboard_id);
            ValueChange[66] = SendNUMPAD0 ? 1 : 0;
            if (Valuechanges._ValueChange[66] > 0f)
                keyboardkey(input, Keys.NUMPAD0, keyboard_id);
            if (Valuechanges._ValueChange[66] < 0f)
                keyboardkeyF(input, Keys.NUMPAD0, keyboard_id);
            ValueChange[67] = SendNUMPAD1 ? 1 : 0;
            if (Valuechanges._ValueChange[67] > 0f)
                keyboardkey(input, Keys.NUMPAD1, keyboard_id);
            if (Valuechanges._ValueChange[67] < 0f)
                keyboardkeyF(input, Keys.NUMPAD1, keyboard_id);
            ValueChange[68] = SendNUMPAD2 ? 1 : 0;
            if (Valuechanges._ValueChange[68] > 0f)
                keyboardkey(input, Keys.NUMPAD2, keyboard_id);
            if (Valuechanges._ValueChange[68] < 0f)
                keyboardkeyF(input, Keys.NUMPAD2, keyboard_id);
            ValueChange[69] = SendNUMPAD3 ? 1 : 0;
            if (Valuechanges._ValueChange[69] > 0f)
                keyboardkey(input, Keys.NUMPAD3, keyboard_id);
            if (Valuechanges._ValueChange[69] < 0f)
                keyboardkeyF(input, Keys.NUMPAD3, keyboard_id);
            ValueChange[70] = SendNUMPAD4 ? 1 : 0;
            if (Valuechanges._ValueChange[70] > 0f)
                keyboardkey(input, Keys.NUMPAD4, keyboard_id);
            if (Valuechanges._ValueChange[70] < 0f)
                keyboardkeyF(input, Keys.NUMPAD4, keyboard_id);
            ValueChange[71] = SendNUMPAD5 ? 1 : 0;
            if (Valuechanges._ValueChange[71] > 0f)
                keyboardkey(input, Keys.NUMPAD5, keyboard_id);
            if (Valuechanges._ValueChange[71] < 0f)
                keyboardkeyF(input, Keys.NUMPAD5, keyboard_id);
            ValueChange[72] = SendNUMPAD6 ? 1 : 0;
            if (Valuechanges._ValueChange[72] > 0f)
                keyboardkey(input, Keys.NUMPAD6, keyboard_id);
            if (Valuechanges._ValueChange[72] < 0f)
                keyboardkeyF(input, Keys.NUMPAD6, keyboard_id);
            ValueChange[73] = SendNUMPAD7 ? 1 : 0;
            if (Valuechanges._ValueChange[73] > 0f)
                keyboardkey(input, Keys.NUMPAD7, keyboard_id);
            if (Valuechanges._ValueChange[73] < 0f)
                keyboardkeyF(input, Keys.NUMPAD7, keyboard_id);
            ValueChange[74] = SendNUMPAD8 ? 1 : 0;
            if (Valuechanges._ValueChange[74] > 0f)
                keyboardkey(input, Keys.NUMPAD8, keyboard_id);
            if (Valuechanges._ValueChange[74] < 0f)
                keyboardkeyF(input, Keys.NUMPAD8, keyboard_id);
            ValueChange[75] = SendNUMPAD9 ? 1 : 0;
            if (Valuechanges._ValueChange[75] > 0f)
                keyboardkey(input, Keys.NUMPAD9, keyboard_id);
            if (Valuechanges._ValueChange[75] < 0f)
                keyboardkeyF(input, Keys.NUMPAD9, keyboard_id);
            ValueChange[76] = SendMULTIPLY ? 1 : 0;
            if (Valuechanges._ValueChange[76] > 0f)
                keyboardkey(input, Keys.MULTIPLY, keyboard_id);
            if (Valuechanges._ValueChange[76] < 0f)
                keyboardkeyF(input, Keys.MULTIPLY, keyboard_id);
            ValueChange[77] = SendADD ? 1 : 0;
            if (Valuechanges._ValueChange[77] > 0f)
                keyboardkey(input, Keys.ADD, keyboard_id);
            if (Valuechanges._ValueChange[77] < 0f)
                keyboardkeyF(input, Keys.ADD, keyboard_id);
            ValueChange[78] = SendSUBTRACT ? 1 : 0;
            if (Valuechanges._ValueChange[78] > 0f)
                keyboardkey(input, Keys.SUBTRACT, keyboard_id);
            if (Valuechanges._ValueChange[78] < 0f)
                keyboardkeyF(input, Keys.SUBTRACT, keyboard_id);
            ValueChange[79] = SendDECIMAL ? 1 : 0;
            if (Valuechanges._ValueChange[79] > 0f)
                keyboardkey(input, Keys.DECIMAL, keyboard_id);
            if (Valuechanges._ValueChange[79] < 0f)
                keyboardkeyF(input, Keys.DECIMAL, keyboard_id);
            ValueChange[80] = SendPRINTSCREEN ? 1 : 0;
            if (Valuechanges._ValueChange[80] > 0f)
                keyboardkey(input, Keys.PRINTSCREEN, keyboard_id);
            if (Valuechanges._ValueChange[80] < 0f)
                keyboardkeyF(input, Keys.PRINTSCREEN, keyboard_id);
            ValueChange[81] = SendDIVIDE ? 1 : 0;
            if (Valuechanges._ValueChange[81] > 0f)
                keyboardkey(input, Keys.DIVIDE, keyboard_id);
            if (Valuechanges._ValueChange[81] < 0f)
                keyboardkeyF(input, Keys.DIVIDE, keyboard_id);
            ValueChange[82] = SendF1 ? 1 : 0;
            if (Valuechanges._ValueChange[82] > 0f)
                keyboardkey(input, Keys.F1, keyboard_id);
            if (Valuechanges._ValueChange[82] < 0f)
                keyboardkeyF(input, Keys.F1, keyboard_id);
            ValueChange[83] = SendF2 ? 1 : 0;
            if (Valuechanges._ValueChange[83] > 0f)
                keyboardkey(input, Keys.F2, keyboard_id);
            if (Valuechanges._ValueChange[83] < 0f)
                keyboardkeyF(input, Keys.F2, keyboard_id);
            ValueChange[84] = SendF3 ? 1 : 0;
            if (Valuechanges._ValueChange[84] > 0f)
                keyboardkey(input, Keys.F3, keyboard_id);
            if (Valuechanges._ValueChange[84] < 0f)
                keyboardkeyF(input, Keys.F3, keyboard_id);
            ValueChange[85] = SendF4 ? 1 : 0;
            if (Valuechanges._ValueChange[85] > 0f)
                keyboardkey(input, Keys.F4, keyboard_id);
            if (Valuechanges._ValueChange[85] < 0f)
                keyboardkeyF(input, Keys.F4, keyboard_id);
            ValueChange[86] = SendF5 ? 1 : 0;
            if (Valuechanges._ValueChange[86] > 0f)
                keyboardkey(input, Keys.F5, keyboard_id);
            if (Valuechanges._ValueChange[86] < 0f)
                keyboardkeyF(input, Keys.F5, keyboard_id);
            ValueChange[87] = SendF6 ? 1 : 0;
            if (Valuechanges._ValueChange[87] > 0f)
                keyboardkey(input, Keys.F6, keyboard_id);
            if (Valuechanges._ValueChange[87] < 0f)
                keyboardkeyF(input, Keys.F6, keyboard_id);
            ValueChange[88] = SendF7 ? 1 : 0;
            if (Valuechanges._ValueChange[88] > 0f)
                keyboardkey(input, Keys.F7, keyboard_id);
            if (Valuechanges._ValueChange[88] < 0f)
                keyboardkeyF(input, Keys.F7, keyboard_id);
            ValueChange[89] = SendF8 ? 1 : 0;
            if (Valuechanges._ValueChange[89] > 0f)
                keyboardkey(input, Keys.F8, keyboard_id);
            if (Valuechanges._ValueChange[89] < 0f)
                keyboardkeyF(input, Keys.F8, keyboard_id);
            ValueChange[90] = SendF9 ? 1 : 0;
            if (Valuechanges._ValueChange[90] > 0f)
                keyboardkey(input, Keys.F9, keyboard_id);
            if (Valuechanges._ValueChange[90] < 0f)
                keyboardkeyF(input, Keys.F9, keyboard_id);
            ValueChange[91] = SendF10 ? 1 : 0;
            if (Valuechanges._ValueChange[91] > 0f)
                keyboardkey(input, Keys.F10, keyboard_id);
            if (Valuechanges._ValueChange[91] < 0f)
                keyboardkeyF(input, Keys.F10, keyboard_id);
            ValueChange[92] = SendF11 ? 1 : 0;
            if (Valuechanges._ValueChange[92] > 0f)
                keyboardkey(input, Keys.F11, keyboard_id);
            if (Valuechanges._ValueChange[92] < 0f)
                keyboardkeyF(input, Keys.F11, keyboard_id);
            ValueChange[93] = SendF12 ? 1 : 0;
            if (Valuechanges._ValueChange[93] > 0f)
                keyboardkey(input, Keys.F12, keyboard_id);
            if (Valuechanges._ValueChange[93] < 0f)
                keyboardkeyF(input, Keys.F12, keyboard_id);
            ValueChange[94] = SendNUMLOCK ? 1 : 0;
            if (Valuechanges._ValueChange[94] > 0f)
                keyboardkey(input, Keys.NUMLOCK, keyboard_id);
            if (Valuechanges._ValueChange[94] < 0f)
                keyboardkeyF(input, Keys.NUMLOCK, keyboard_id);
            ValueChange[95] = SendSCROLLLOCK ? 1 : 0;
            if (Valuechanges._ValueChange[95] > 0f)
                keyboardkey(input, Keys.SCROLLLOCK, keyboard_id);
            if (Valuechanges._ValueChange[95] < 0f)
                keyboardkeyF(input, Keys.SCROLLLOCK, keyboard_id);
            ValueChange[96] = SendLEFTSHIFT ? 1 : 0;
            if (Valuechanges._ValueChange[96] > 0f)
                keyboardkey(input, Keys.LEFTSHIFT, keyboard_id);
            if (Valuechanges._ValueChange[96] < 0f)
                keyboardkeyF(input, Keys.LEFTSHIFT, keyboard_id);
            ValueChange[97] = SendRIGHTSHIFT ? 1 : 0;
            if (Valuechanges._ValueChange[97] > 0f)
                keyboardkey(input, Keys.RIGHTSHIFT, keyboard_id);
            if (Valuechanges._ValueChange[97] < 0f)
                keyboardkeyF(input, Keys.RIGHTSHIFT, keyboard_id);
            ValueChange[98] = SendLEFTCONTROL ? 1 : 0;
            if (Valuechanges._ValueChange[98] > 0f)
                keyboardkey(input, Keys.LEFTCONTROL, keyboard_id);
            if (Valuechanges._ValueChange[98] < 0f)
                keyboardkeyF(input, Keys.LEFTCONTROL, keyboard_id);
            ValueChange[99] = SendRIGHTCONTROL ? 1 : 0;
            if (Valuechanges._ValueChange[99] > 0f)
                keyboardkey(input, Keys.RIGHTCONTROL, keyboard_id);
            if (Valuechanges._ValueChange[99] < 0f)
                keyboardkeyF(input, Keys.RIGHTCONTROL, keyboard_id);
            ValueChange[100] = SendLEFTALT ? 1 : 0;
            if (Valuechanges._ValueChange[100] > 0f)
                keyboardkey(input, Keys.LEFTALT, keyboard_id);
            if (Valuechanges._ValueChange[100] < 0f)
                keyboardkeyF(input, Keys.LEFTALT, keyboard_id);
            ValueChange[101] = SendRIGHTALT ? 1 : 0;
            if (Valuechanges._ValueChange[101] > 0f)
                keyboardkey(input, Keys.RIGHTALT, keyboard_id);
            if (Valuechanges._ValueChange[101] < 0f)
                keyboardkeyF(input, Keys.RIGHTALT, keyboard_id);
            ValueChange[102] = SendBROWSER_BACK ? 1 : 0;
            if (Valuechanges._ValueChange[102] > 0f)
                keyboardkey(input, Keys.BROWSER_BACK, keyboard_id);
            if (Valuechanges._ValueChange[102] < 0f)
                keyboardkeyF(input, Keys.BROWSER_BACK, keyboard_id);
            ValueChange[103] = SendBROWSER_FORWARD ? 1 : 0;
            if (Valuechanges._ValueChange[103] > 0f)
                keyboardkey(input, Keys.BROWSER_FORWARD, keyboard_id);
            if (Valuechanges._ValueChange[103] < 0f)
                keyboardkeyF(input, Keys.BROWSER_FORWARD, keyboard_id);
            ValueChange[104] = SendBROWSER_REFRESH ? 1 : 0;
            if (Valuechanges._ValueChange[104] > 0f)
                keyboardkey(input, Keys.BROWSER_REFRESH, keyboard_id);
            if (Valuechanges._ValueChange[104] < 0f)
                keyboardkeyF(input, Keys.BROWSER_REFRESH, keyboard_id);
            ValueChange[105] = SendBROWSER_STOP ? 1 : 0;
            if (Valuechanges._ValueChange[105] > 0f)
                keyboardkey(input, Keys.BROWSER_STOP, keyboard_id);
            if (Valuechanges._ValueChange[105] < 0f)
                keyboardkeyF(input, Keys.BROWSER_STOP, keyboard_id);
            ValueChange[106] = SendBROWSER_SEARCH ? 1 : 0;
            if (Valuechanges._ValueChange[106] > 0f)
                keyboardkey(input, Keys.BROWSER_SEARCH, keyboard_id);
            if (Valuechanges._ValueChange[106] < 0f)
                keyboardkeyF(input, Keys.BROWSER_SEARCH, keyboard_id);
            ValueChange[107] = SendBROWSER_FAVORITES ? 1 : 0;
            if (Valuechanges._ValueChange[107] > 0f)
                keyboardkey(input, Keys.BROWSER_FAVORITES, keyboard_id);
            if (Valuechanges._ValueChange[107] < 0f)
                keyboardkeyF(input, Keys.BROWSER_FAVORITES, keyboard_id);
            ValueChange[108] = SendBROWSER_HOME ? 1 : 0;
            if (Valuechanges._ValueChange[108] > 0f)
                keyboardkey(input, Keys.BROWSER_HOME, keyboard_id);
            if (Valuechanges._ValueChange[108] < 0f)
                keyboardkeyF(input, Keys.BROWSER_HOME, keyboard_id);
            ValueChange[109] = SendVOLUME_MUTE ? 1 : 0;
            if (Valuechanges._ValueChange[109] > 0f)
                keyboardkey(input, Keys.VOLUME_MUTE, keyboard_id);
            if (Valuechanges._ValueChange[109] < 0f)
                keyboardkeyF(input, Keys.VOLUME_MUTE, keyboard_id);
            ValueChange[110] = SendVOLUME_DOWN ? 1 : 0;
            if (Valuechanges._ValueChange[110] > 0f)
                keyboardkey(input, Keys.VOLUME_DOWN, keyboard_id);
            if (Valuechanges._ValueChange[110] < 0f)
                keyboardkeyF(input, Keys.VOLUME_DOWN, keyboard_id);
            ValueChange[111] = SendVOLUME_UP ? 1 : 0;
            if (Valuechanges._ValueChange[111] > 0f)
                keyboardkey(input, Keys.VOLUME_UP, keyboard_id);
            if (Valuechanges._ValueChange[111] < 0f)
                keyboardkeyF(input, Keys.VOLUME_UP, keyboard_id);
            ValueChange[112] = SendMEDIA_NEXT_TRACK ? 1 : 0;
            if (Valuechanges._ValueChange[112] > 0f)
                keyboardkey(input, Keys.MEDIA_NEXT_TRACK, keyboard_id);
            if (Valuechanges._ValueChange[112] < 0f)
                keyboardkeyF(input, Keys.MEDIA_NEXT_TRACK, keyboard_id);
            ValueChange[113] = SendMEDIA_PREV_TRACK ? 1 : 0;
            if (Valuechanges._ValueChange[113] > 0f)
                keyboardkey(input, Keys.MEDIA_PREV_TRACK, keyboard_id);
            if (Valuechanges._ValueChange[113] < 0f)
                keyboardkeyF(input, Keys.MEDIA_PREV_TRACK, keyboard_id);
            ValueChange[114] = SendMEDIA_STOP ? 1 : 0;
            if (Valuechanges._ValueChange[114] > 0f)
                keyboardkey(input, Keys.MEDIA_STOP, keyboard_id);
            if (Valuechanges._ValueChange[114] < 0f)
                keyboardkeyF(input, Keys.MEDIA_STOP, keyboard_id);
            ValueChange[115] = SendMEDIA_PLAY_PAUSE ? 1 : 0;
            if (Valuechanges._ValueChange[115] > 0f)
                keyboardkey(input, Keys.MEDIA_PLAY_PAUSE, keyboard_id);
            if (Valuechanges._ValueChange[115] < 0f)
                keyboardkeyF(input, Keys.MEDIA_PLAY_PAUSE, keyboard_id);
            ValueChange[116] = SendLAUNCH_MAIL ? 1 : 0;
            if (Valuechanges._ValueChange[116] > 0f)
                keyboardkey(input, Keys.LAUNCH_MAIL, keyboard_id);
            if (Valuechanges._ValueChange[116] < 0f)
                keyboardkeyF(input, Keys.LAUNCH_MAIL, keyboard_id);
            ValueChange[117] = SendLAUNCH_MEDIA_SELECT ? 1 : 0;
            if (Valuechanges._ValueChange[117] > 0f)
                keyboardkey(input, Keys.LAUNCH_MEDIA_SELECT, keyboard_id);
            if (Valuechanges._ValueChange[117] < 0f)
                keyboardkeyF(input, Keys.LAUNCH_MEDIA_SELECT, keyboard_id);
            ValueChange[118] = SendLAUNCH_APP1 ? 1 : 0;
            if (Valuechanges._ValueChange[118] > 0f)
                keyboardkey(input, Keys.LAUNCH_APP1, keyboard_id);
            if (Valuechanges._ValueChange[118] < 0f)
                keyboardkeyF(input, Keys.LAUNCH_APP1, keyboard_id);
            ValueChange[119] = SendLAUNCH_APP2 ? 1 : 0;
            if (Valuechanges._ValueChange[119] > 0f)
                keyboardkey(input, Keys.LAUNCH_APP2, keyboard_id);
            if (Valuechanges._ValueChange[119] < 0f)
                keyboardkeyF(input, Keys.LAUNCH_APP2, keyboard_id);
            ValueChange[120] = SendOEM_1 ? 1 : 0;
            if (Valuechanges._ValueChange[120] > 0f)
                keyboardkey(input, Keys.OEM_1, keyboard_id);
            if (Valuechanges._ValueChange[120] < 0f)
                keyboardkeyF(input, Keys.OEM_1, keyboard_id);
            ValueChange[121] = SendOEM_PLUS ? 1 : 0;
            if (Valuechanges._ValueChange[121] > 0f)
                keyboardkey(input, Keys.OEM_PLUS, keyboard_id);
            if (Valuechanges._ValueChange[121] < 0f)
                keyboardkeyF(input, Keys.OEM_PLUS, keyboard_id);
            ValueChange[122] = SendOEM_COMMA ? 1 : 0;
            if (Valuechanges._ValueChange[122] > 0f)
                keyboardkey(input, Keys.OEM_COMMA, keyboard_id);
            if (Valuechanges._ValueChange[122] < 0f)
                keyboardkeyF(input, Keys.OEM_COMMA, keyboard_id);
            ValueChange[123] = SendOEM_MINUS ? 1 : 0;
            if (Valuechanges._ValueChange[123] > 0f)
                keyboardkey(input, Keys.OEM_MINUS, keyboard_id);
            if (Valuechanges._ValueChange[123] < 0f)
                keyboardkeyF(input, Keys.OEM_MINUS, keyboard_id);
            ValueChange[124] = SendOEM_PERIOD ? 1 : 0;
            if (Valuechanges._ValueChange[124] > 0f)
                keyboardkey(input, Keys.OEM_PERIOD, keyboard_id);
            if (Valuechanges._ValueChange[124] < 0f)
                keyboardkeyF(input, Keys.OEM_PERIOD, keyboard_id);
            ValueChange[125] = SendOEM_2 ? 1 : 0;
            if (Valuechanges._ValueChange[125] > 0f)
                keyboardkey(input, Keys.OEM_2, keyboard_id);
            if (Valuechanges._ValueChange[125] < 0f)
                keyboardkeyF(input, Keys.OEM_2, keyboard_id);
            ValueChange[126] = SendOEM_3 ? 1 : 0;
            if (Valuechanges._ValueChange[126] > 0f)
                keyboardkey(input, Keys.OEM_3, keyboard_id);
            if (Valuechanges._ValueChange[126] < 0f)
                keyboardkeyF(input, Keys.OEM_3, keyboard_id);
            ValueChange[127] = SendOEM_4 ? 1 : 0;
            if (Valuechanges._ValueChange[127] > 0f)
                keyboardkey(input, Keys.OEM_4, keyboard_id);
            if (Valuechanges._ValueChange[127] < 0f)
                keyboardkeyF(input, Keys.OEM_4, keyboard_id);
            ValueChange[128] = SendOEM_5 ? 1 : 0;
            if (Valuechanges._ValueChange[128] > 0f)
                keyboardkey(input, Keys.OEM_5, keyboard_id);
            if (Valuechanges._ValueChange[128] < 0f)
                keyboardkeyF(input, Keys.OEM_5, keyboard_id);
            ValueChange[129] = SendOEM_6 ? 1 : 0;
            if (Valuechanges._ValueChange[129] > 0f)
                keyboardkey(input, Keys.OEM_6, keyboard_id);
            if (Valuechanges._ValueChange[129] < 0f)
                keyboardkeyF(input, Keys.OEM_6, keyboard_id);
            ValueChange[130] = SendOEM_7 ? 1 : 0;
            if (Valuechanges._ValueChange[130] > 0f)
                keyboardkey(input, Keys.OEM_7, keyboard_id);
            if (Valuechanges._ValueChange[130] < 0f)
                keyboardkeyF(input, Keys.OEM_7, keyboard_id);
            ValueChange[131] = SendOEM_8 ? 1 : 0;
            if (Valuechanges._ValueChange[131] > 0f)
                keyboardkey(input, Keys.OEM_8, keyboard_id);
            if (Valuechanges._ValueChange[131] < 0f)
                keyboardkeyF(input, Keys.OEM_8, keyboard_id);
            ValueChange[132] = SendOEM_102 ? 1 : 0;
            if (Valuechanges._ValueChange[132] > 0f)
                keyboardkey(input, Keys.OEM_102, keyboard_id);
            if (Valuechanges._ValueChange[132] < 0f)
                keyboardkeyF(input, Keys.OEM_102, keyboard_id);
            ValueChange[133] = SendEREOF ? 1 : 0;
            if (Valuechanges._ValueChange[133] > 0f)
                keyboardkey(input, Keys.EREOF, keyboard_id);
            if (Valuechanges._ValueChange[133] < 0f)
                keyboardkeyF(input, Keys.EREOF, keyboard_id);
            ValueChange[134] = SendZOOM ? 1 : 0;
            if (Valuechanges._ValueChange[134] > 0f)
                keyboardkey(input, Keys.ZOOM, keyboard_id);
            if (Valuechanges._ValueChange[134] < 0f)
                keyboardkeyF(input, Keys.ZOOM, keyboard_id);
            ValueChange[135] = SendEscape ? 1 : 0;
            if (Valuechanges._ValueChange[135] > 0f)
                keyboardkey(input, Keys.Escape, keyboard_id);
            if (Valuechanges._ValueChange[135] < 0f)
                keyboardkeyF(input, Keys.Escape, keyboard_id);
            ValueChange[136] = SendOne ? 1 : 0;
            if (Valuechanges._ValueChange[136] > 0f)
                keyboardkey(input, Keys.One, keyboard_id);
            if (Valuechanges._ValueChange[136] < 0f)
                keyboardkeyF(input, Keys.One, keyboard_id);
            ValueChange[137] = SendTwo ? 1 : 0;
            if (Valuechanges._ValueChange[137] > 0f)
                keyboardkey(input, Keys.Two, keyboard_id);
            if (Valuechanges._ValueChange[137] < 0f)
                keyboardkeyF(input, Keys.Two, keyboard_id);
            ValueChange[138] = SendThree ? 1 : 0;
            if (Valuechanges._ValueChange[138] > 0f)
                keyboardkey(input, Keys.Three, keyboard_id);
            if (Valuechanges._ValueChange[138] < 0f)
                keyboardkeyF(input, Keys.Three, keyboard_id);
            ValueChange[139] = SendFour ? 1 : 0;
            if (Valuechanges._ValueChange[139] > 0f)
                keyboardkey(input, Keys.Four, keyboard_id);
            if (Valuechanges._ValueChange[139] < 0f)
                keyboardkeyF(input, Keys.Four, keyboard_id);
            ValueChange[140] = SendFive ? 1 : 0;
            if (Valuechanges._ValueChange[140] > 0f)
                keyboardkey(input, Keys.Five, keyboard_id);
            if (Valuechanges._ValueChange[140] < 0f)
                keyboardkeyF(input, Keys.Five, keyboard_id);
            ValueChange[141] = SendSix ? 1 : 0;
            if (Valuechanges._ValueChange[141] > 0f)
                keyboardkey(input, Keys.Six, keyboard_id);
            if (Valuechanges._ValueChange[141] < 0f)
                keyboardkeyF(input, Keys.Six, keyboard_id);
            ValueChange[142] = SendSeven ? 1 : 0;
            if (Valuechanges._ValueChange[142] > 0f)
                keyboardkey(input, Keys.Seven, keyboard_id);
            if (Valuechanges._ValueChange[142] < 0f)
                keyboardkeyF(input, Keys.Seven, keyboard_id);
            ValueChange[143] = SendEight ? 1 : 0;
            if (Valuechanges._ValueChange[143] > 0f)
                keyboardkey(input, Keys.Eight, keyboard_id);
            if (Valuechanges._ValueChange[143] < 0f)
                keyboardkeyF(input, Keys.Eight, keyboard_id);
            ValueChange[144] = SendNine ? 1 : 0;
            if (Valuechanges._ValueChange[144] > 0f)
                keyboardkey(input, Keys.Nine, keyboard_id);
            if (Valuechanges._ValueChange[144] < 0f)
                keyboardkeyF(input, Keys.Nine, keyboard_id);
            ValueChange[145] = SendZero ? 1 : 0;
            if (Valuechanges._ValueChange[145] > 0f)
                keyboardkey(input, Keys.Zero, keyboard_id);
            if (Valuechanges._ValueChange[145] < 0f)
                keyboardkeyF(input, Keys.Zero, keyboard_id);
            ValueChange[146] = SendDashUnderscore ? 1 : 0;
            if (Valuechanges._ValueChange[146] > 0f)
                keyboardkey(input, Keys.DashUnderscore, keyboard_id);
            if (Valuechanges._ValueChange[146] < 0f)
                keyboardkeyF(input, Keys.DashUnderscore, keyboard_id);
            ValueChange[147] = SendPlusEquals ? 1 : 0;
            if (Valuechanges._ValueChange[147] > 0f)
                keyboardkey(input, Keys.PlusEquals, keyboard_id);
            if (Valuechanges._ValueChange[147] < 0f)
                keyboardkeyF(input, Keys.PlusEquals, keyboard_id);
            ValueChange[148] = SendBackspace ? 1 : 0;
            if (Valuechanges._ValueChange[148] > 0f)
                keyboardkey(input, Keys.Backspace, keyboard_id);
            if (Valuechanges._ValueChange[148] < 0f)
                keyboardkeyF(input, Keys.Backspace, keyboard_id);
            ValueChange[149] = SendTab ? 1 : 0;
            if (Valuechanges._ValueChange[149] > 0f)
                keyboardkey(input, Keys.Tab, keyboard_id);
            if (Valuechanges._ValueChange[149] < 0f)
                keyboardkeyF(input, Keys.Tab, keyboard_id);
            ValueChange[150] = SendOpenBracketBrace ? 1 : 0;
            if (Valuechanges._ValueChange[150] > 0f)
                keyboardkey(input, Keys.OpenBracketBrace, keyboard_id);
            if (Valuechanges._ValueChange[150] < 0f)
                keyboardkeyF(input, Keys.OpenBracketBrace, keyboard_id);
            ValueChange[151] = SendCloseBracketBrace ? 1 : 0;
            if (Valuechanges._ValueChange[151] > 0f)
                keyboardkey(input, Keys.CloseBracketBrace, keyboard_id);
            if (Valuechanges._ValueChange[151] < 0f)
                keyboardkeyF(input, Keys.CloseBracketBrace, keyboard_id);
            ValueChange[152] = SendEnter ? 1 : 0;
            if (Valuechanges._ValueChange[152] > 0f)
                keyboardkey(input, Keys.Enter, keyboard_id);
            if (Valuechanges._ValueChange[152] < 0f)
                keyboardkeyF(input, Keys.Enter, keyboard_id);
            ValueChange[153] = SendSemicolonColon ? 1 : 0;
            if (Valuechanges._ValueChange[153] > 0f)
                keyboardkey(input, Keys.SemicolonColon, keyboard_id);
            if (Valuechanges._ValueChange[153] < 0f)
                keyboardkeyF(input, Keys.SemicolonColon, keyboard_id);
            ValueChange[154] = SendSingleDoubleQuote ? 1 : 0;
            if (Valuechanges._ValueChange[154] > 0f)
                keyboardkey(input, Keys.SingleDoubleQuote, keyboard_id);
            if (Valuechanges._ValueChange[154] < 0f)
                keyboardkeyF(input, Keys.SingleDoubleQuote, keyboard_id);
            ValueChange[155] = SendTilde ? 1 : 0;
            if (Valuechanges._ValueChange[155] > 0f)
                keyboardkey(input, Keys.Tilde, keyboard_id);
            if (Valuechanges._ValueChange[155] < 0f)
                keyboardkeyF(input, Keys.Tilde, keyboard_id);
            ValueChange[156] = SendLeftShift ? 1 : 0;
            if (Valuechanges._ValueChange[156] > 0f)
                keyboardkey(input, Keys.LeftShift, keyboard_id);
            if (Valuechanges._ValueChange[156] < 0f)
                keyboardkeyF(input, Keys.LeftShift, keyboard_id);
            ValueChange[157] = SendBackslashPipe ? 1 : 0;
            if (Valuechanges._ValueChange[157] > 0f)
                keyboardkey(input, Keys.BackslashPipe, keyboard_id);
            if (Valuechanges._ValueChange[157] < 0f)
                keyboardkeyF(input, Keys.BackslashPipe, keyboard_id);
            ValueChange[158] = SendCommaLeftArrow ? 1 : 0;
            if (Valuechanges._ValueChange[158] > 0f)
                keyboardkey(input, Keys.CommaLeftArrow, keyboard_id);
            if (Valuechanges._ValueChange[158] < 0f)
                keyboardkeyF(input, Keys.CommaLeftArrow, keyboard_id);
            ValueChange[159] = SendPeriodRightArrow ? 1 : 0;
            if (Valuechanges._ValueChange[159] > 0f)
                keyboardkey(input, Keys.PeriodRightArrow, keyboard_id);
            if (Valuechanges._ValueChange[159] < 0f)
                keyboardkeyF(input, Keys.PeriodRightArrow, keyboard_id);
            ValueChange[160] = SendForwardSlashQuestionMark ? 1 : 0;
            if (Valuechanges._ValueChange[160] > 0f)
                keyboardkey(input, Keys.ForwardSlashQuestionMark, keyboard_id);
            if (Valuechanges._ValueChange[160] < 0f)
                keyboardkeyF(input, Keys.ForwardSlashQuestionMark, keyboard_id);
            ValueChange[161] = SendRightShift ? 1 : 0;
            if (Valuechanges._ValueChange[161] > 0f)
                keyboardkey(input, Keys.RightShift, keyboard_id);
            if (Valuechanges._ValueChange[161] < 0f)
                keyboardkeyF(input, Keys.RightShift, keyboard_id);
            ValueChange[162] = SendRightAlt ? 1 : 0;
            if (Valuechanges._ValueChange[162] > 0f)
                keyboardkey(input, Keys.RightAlt, keyboard_id);
            if (Valuechanges._ValueChange[162] < 0f)
                keyboardkeyF(input, Keys.RightAlt, keyboard_id);
            ValueChange[163] = SendSpace ? 1 : 0;
            if (Valuechanges._ValueChange[163] > 0f)
                keyboardkey(input, Keys.Space, keyboard_id);
            if (Valuechanges._ValueChange[163] < 0f)
                keyboardkeyF(input, Keys.Space, keyboard_id);
            ValueChange[164] = SendCapsLock ? 1 : 0;
            if (Valuechanges._ValueChange[164] > 0f)
                keyboardkey(input, Keys.CapsLock, keyboard_id);
            if (Valuechanges._ValueChange[164] < 0f)
                keyboardkeyF(input, Keys.CapsLock, keyboard_id);
            ValueChange[165] = SendUp ? 1 : 0;
            if (Valuechanges._ValueChange[165] > 0f)
                keyboardkey(input, Keys.Up, keyboard_id);
            if (Valuechanges._ValueChange[165] < 0f)
                keyboardkeyF(input, Keys.Up, keyboard_id);
            ValueChange[166] = SendDown ? 1 : 0;
            if (Valuechanges._ValueChange[166] > 0f)
                keyboardkey(input, Keys.Down, keyboard_id);
            if (Valuechanges._ValueChange[166] < 0f)
                keyboardkeyF(input, Keys.Down, keyboard_id);
            ValueChange[167] = SendRight ? 1 : 0;
            if (Valuechanges._ValueChange[167] > 0f)
                keyboardkey(input, Keys.Right, keyboard_id);
            if (Valuechanges._ValueChange[167] < 0f)
                keyboardkeyF(input, Keys.Right, keyboard_id);
            ValueChange[168] = SendLeft ? 1 : 0;
            if (Valuechanges._ValueChange[168] > 0f)
                keyboardkey(input, Keys.Left, keyboard_id);
            if (Valuechanges._ValueChange[168] < 0f)
                keyboardkeyF(input, Keys.Left, keyboard_id);
            ValueChange[169] = SendHome ? 1 : 0;
            if (Valuechanges._ValueChange[169] > 0f)
                keyboardkey(input, Keys.Home, keyboard_id);
            if (Valuechanges._ValueChange[169] < 0f)
                keyboardkeyF(input, Keys.Home, keyboard_id);
            ValueChange[170] = SendEnd ? 1 : 0;
            if (Valuechanges._ValueChange[170] > 0f)
                keyboardkey(input, Keys.End, keyboard_id);
            if (Valuechanges._ValueChange[170] < 0f)
                keyboardkeyF(input, Keys.End, keyboard_id);
            ValueChange[171] = SendDelete ? 1 : 0;
            if (Valuechanges._ValueChange[171] > 0f)
                keyboardkey(input, Keys.Delete, keyboard_id);
            if (Valuechanges._ValueChange[171] < 0f)
                keyboardkeyF(input, Keys.Delete, keyboard_id);
            ValueChange[172] = SendPageUp ? 1 : 0;
            if (Valuechanges._ValueChange[172] > 0f)
                keyboardkey(input, Keys.PageUp, keyboard_id);
            if (Valuechanges._ValueChange[172] < 0f)
                keyboardkeyF(input, Keys.PageUp, keyboard_id);
            ValueChange[173] = SendPageDown ? 1 : 0;
            if (Valuechanges._ValueChange[173] > 0f)
                keyboardkey(input, Keys.PageDown, keyboard_id);
            if (Valuechanges._ValueChange[173] < 0f)
                keyboardkeyF(input, Keys.PageDown, keyboard_id);
            ValueChange[174] = SendInsert ? 1 : 0;
            if (Valuechanges._ValueChange[174] > 0f)
                keyboardkey(input, Keys.Insert, keyboard_id);
            if (Valuechanges._ValueChange[174] < 0f)
                keyboardkeyF(input, Keys.Insert, keyboard_id);
            ValueChange[175] = SendPrintScreen ? 1 : 0;
            if (Valuechanges._ValueChange[175] > 0f)
                keyboardkey(input, Keys.PrintScreen, keyboard_id);
            if (Valuechanges._ValueChange[175] < 0f)
                keyboardkeyF(input, Keys.PrintScreen, keyboard_id);
            ValueChange[176] = SendNumLock ? 1 : 0;
            if (Valuechanges._ValueChange[176] > 0f)
                keyboardkey(input, Keys.NumLock, keyboard_id);
            if (Valuechanges._ValueChange[176] < 0f)
                keyboardkeyF(input, Keys.NumLock, keyboard_id);
            ValueChange[177] = SendScrollLock ? 1 : 0;
            if (Valuechanges._ValueChange[177] > 0f)
                keyboardkey(input, Keys.ScrollLock, keyboard_id);
            if (Valuechanges._ValueChange[177] < 0f)
                keyboardkeyF(input, Keys.ScrollLock, keyboard_id);
            ValueChange[178] = SendMenu ? 1 : 0;
            if (Valuechanges._ValueChange[178] > 0f)
                keyboardkey(input, Keys.Menu, keyboard_id);
            if (Valuechanges._ValueChange[178] < 0f)
                keyboardkeyF(input, Keys.Menu, keyboard_id);
            ValueChange[179] = SendWindowsKey ? 1 : 0;
            if (Valuechanges._ValueChange[179] > 0f)
                keyboardkey(input, Keys.WindowsKey, keyboard_id);
            if (Valuechanges._ValueChange[179] < 0f)
                keyboardkeyF(input, Keys.WindowsKey, keyboard_id);
            ValueChange[180] = SendNumpadDivide ? 1 : 0;
            if (Valuechanges._ValueChange[180] > 0f)
                keyboardkey(input, Keys.NumpadDivide, keyboard_id);
            if (Valuechanges._ValueChange[180] < 0f)
                keyboardkeyF(input, Keys.NumpadDivide, keyboard_id);
            ValueChange[181] = SendNumpadAsterisk ? 1 : 0;
            if (Valuechanges._ValueChange[181] > 0f)
                keyboardkey(input, Keys.NumpadAsterisk, keyboard_id);
            if (Valuechanges._ValueChange[181] < 0f)
                keyboardkeyF(input, Keys.NumpadAsterisk, keyboard_id);
            ValueChange[182] = SendNumpad7 ? 1 : 0;
            if (Valuechanges._ValueChange[182] > 0f)
                keyboardkey(input, Keys.Numpad7, keyboard_id);
            if (Valuechanges._ValueChange[182] < 0f)
                keyboardkeyF(input, Keys.Numpad7, keyboard_id);
            ValueChange[183] = SendNumpad8 ? 1 : 0;
            if (Valuechanges._ValueChange[183] > 0f)
                keyboardkey(input, Keys.Numpad8, keyboard_id);
            if (Valuechanges._ValueChange[183] < 0f)
                keyboardkeyF(input, Keys.Numpad8, keyboard_id);
            ValueChange[184] = SendNumpad9 ? 1 : 0;
            if (Valuechanges._ValueChange[184] > 0f)
                keyboardkey(input, Keys.Numpad9, keyboard_id);
            if (Valuechanges._ValueChange[184] < 0f)
                keyboardkeyF(input, Keys.Numpad9, keyboard_id);
            ValueChange[185] = SendNumpad4 ? 1 : 0;
            if (Valuechanges._ValueChange[185] > 0f)
                keyboardkey(input, Keys.Numpad4, keyboard_id);
            if (Valuechanges._ValueChange[185] < 0f)
                keyboardkeyF(input, Keys.Numpad4, keyboard_id);
            ValueChange[186] = SendNumpad5 ? 1 : 0;
            if (Valuechanges._ValueChange[186] > 0f)
                keyboardkey(input, Keys.Numpad5, keyboard_id);
            if (Valuechanges._ValueChange[186] < 0f)
                keyboardkeyF(input, Keys.Numpad5, keyboard_id);
            ValueChange[187] = SendNumpad6 ? 1 : 0;
            if (Valuechanges._ValueChange[187] > 0f)
                keyboardkey(input, Keys.Numpad6, keyboard_id);
            if (Valuechanges._ValueChange[187] < 0f)
                keyboardkeyF(input, Keys.Numpad6, keyboard_id);
            ValueChange[188] = SendNumpad1 ? 1 : 0;
            if (Valuechanges._ValueChange[188] > 0f)
                keyboardkey(input, Keys.Numpad1, keyboard_id);
            if (Valuechanges._ValueChange[188] < 0f)
                keyboardkeyF(input, Keys.Numpad1, keyboard_id);
            ValueChange[189] = SendNumpad2 ? 1 : 0;
            if (Valuechanges._ValueChange[189] > 0f)
                keyboardkey(input, Keys.Numpad2, keyboard_id);
            if (Valuechanges._ValueChange[189] < 0f)
                keyboardkeyF(input, Keys.Numpad2, keyboard_id);
            ValueChange[190] = SendNumpad3 ? 1 : 0;
            if (Valuechanges._ValueChange[190] > 0f)
                keyboardkey(input, Keys.Numpad3, keyboard_id);
            if (Valuechanges._ValueChange[190] < 0f)
                keyboardkeyF(input, Keys.Numpad3, keyboard_id);
            ValueChange[191] = SendNumpad0 ? 1 : 0;
            if (Valuechanges._ValueChange[191] > 0f)
                keyboardkey(input, Keys.Numpad0, keyboard_id);
            if (Valuechanges._ValueChange[191] < 0f)
                keyboardkeyF(input, Keys.Numpad0, keyboard_id);
            ValueChange[192] = SendNumpadDelete ? 1 : 0;
            if (Valuechanges._ValueChange[192] > 0f)
                keyboardkey(input, Keys.NumpadDelete, keyboard_id);
            if (Valuechanges._ValueChange[192] < 0f)
                keyboardkeyF(input, Keys.NumpadDelete, keyboard_id);
            ValueChange[193] = SendNumpadEnter ? 1 : 0;
            if (Valuechanges._ValueChange[193] > 0f)
                keyboardkey(input, Keys.NumpadEnter, keyboard_id);
            if (Valuechanges._ValueChange[193] < 0f)
                keyboardkeyF(input, Keys.NumpadEnter, keyboard_id);
            ValueChange[194] = SendNumpadPlus ? 1 : 0;
            if (Valuechanges._ValueChange[194] > 0f)
                keyboardkey(input, Keys.NumpadPlus, keyboard_id);
            if (Valuechanges._ValueChange[194] < 0f)
                keyboardkeyF(input, Keys.NumpadPlus, keyboard_id);
            ValueChange[195] = SendNumpadMinus ? 1 : 0;
            if (Valuechanges._ValueChange[195] > 0f)
                keyboardkey(input, Keys.NumpadMinus, keyboard_id);
            if (Valuechanges._ValueChange[195] < 0f)
                keyboardkeyF(input, Keys.NumpadMinus, keyboard_id);
        }
        public static void mouseclickleft(Input input, int mouse_id)
        {
            input.SendLeftClick(mouse_id);
        }
        public static void mouseclickleftF(Input input, int mouse_id)
        {
            input.SendLeftClickF(mouse_id);
        }
        public static void mouseclickright(Input input, int mouse_id)
        {
            input.SendRightClick(mouse_id);
        }
        public static void mouseclickrightF(Input input, int mouse_id)
        {
            input.SendRightClickF(mouse_id);
        }
        public static void mouseclickmiddle(Input input, int mouse_id)
        {
            input.SendMiddleClick(mouse_id);
        }
        public static void mouseclickmiddleF(Input input, int mouse_id)
        {
            input.SendMiddleClickF(mouse_id);
        }
        public static void mousewheelup(Input input, int mouse_id)
        {
            input.SendWheelUp(mouse_id);
        }
        public static void mousewheeldown(Input input, int mouse_id)
        {
            input.SendWheelDown(mouse_id);
        }
        public static void keyboardkey(Input input, Keys key, int keyboard_id)
        {
            input.SendKey(key, keyboard_id);
        }
        public static void keyboardkeyF(Input input, Keys key, int keyboard_id)
        {
            input.SendKeyF(key, keyboard_id);
        }
        public static void MoveMouseBy(Input input, int deltaX, int deltaY, int mouseId)
        {
            input.MoveMouseBy(deltaX, deltaY, mouseId);
        }
        public static void MoveMouseTo(Input input, int x, int y, int mouseId)
        {
            input.MoveMouseTo(x, y, mouseId);
        }
    }
    public class Input
    {
        private static IntPtr context;
        public KeyboardFilterMode KeyboardFilterMode { get; set; }
        public MouseFilterMode MouseFilterMode { get; set; }
        public static bool IsLoaded { get; set; }
        public Input()
        {
            context = IntPtr.Zero;
            KeyboardFilterMode = KeyboardFilterMode.None;
            MouseFilterMode = MouseFilterMode.None;
        }
        public bool Load()
        {
            context = InterceptionDriver.CreateContext();
            return true;
        }
        public void Unload()
        {
            InterceptionDriver.DestroyContext(context);
        }
        public void SendKey(Keys key, KeyState state, int keyboardId)
        {
            Stroke stroke = new Stroke();
            KeyStroke keyStroke = new KeyStroke();
            keyStroke.Code = key;
            keyStroke.State = state;
            stroke.Key = keyStroke;
            InterceptionDriver.Send(context, keyboardId, ref stroke, 1);
        }
        public void SendKey(Keys key, int keyboardId)
        {
            SendKey(key, KeyState.Down, keyboardId);
        }
        public void SendKeyF(Keys key, int keyboardId)
        {
            SendKey(key, KeyState.Up, keyboardId);
        }
        public void SendMouseEvent(MouseState state, int mouseId)
        {
            Stroke stroke = new Stroke();
            MouseStroke mouseStroke = new MouseStroke();
            mouseStroke.State = state;
            if (state == MouseState.ScrollUp)
            {
                mouseStroke.Rolling = 120;
            }
            else if (state == MouseState.ScrollDown)
            {
                mouseStroke.Rolling = -120;
            }
            stroke.Mouse = mouseStroke;
            InterceptionDriver.Send(context, mouseId, ref stroke, 1);
        }
        public void SendLeftClick(int mouseId)
        {
            SendMouseEvent(MouseState.LeftDown, mouseId);
        }
        public void SendRightClick(int mouseId)
        {
            SendMouseEvent(MouseState.RightDown, mouseId);
        }
        public void SendLeftClickF(int mouseId)
        {
            SendMouseEvent(MouseState.LeftUp, mouseId);
        }
        public void SendRightClickF(int mouseId)
        {
            SendMouseEvent(MouseState.RightUp, mouseId);
        }
        public void SendMiddleClick(int mouseId)
        {
            SendMouseEvent(MouseState.MiddleDown, mouseId);
        }
        public void SendMiddleClickF(int mouseId)
        {
            SendMouseEvent(MouseState.MiddleUp, mouseId);
        }
        public void SendWheelUp(int mouseId)
        {
            SendMouseEvent(MouseState.ScrollUp, mouseId);
        }
        public void SendWheelDown(int mouseId)
        {
            SendMouseEvent(MouseState.ScrollDown, mouseId);
        }
        public void MoveMouseBy(int deltaX, int deltaY, int mouseId)
        {
            if (deltaX != 0 | deltaY != 0)
            {
                Stroke stroke = new Stroke();
                MouseStroke mouseStroke = new MouseStroke();
                mouseStroke.X = deltaX;
                mouseStroke.Y = deltaY;
                stroke.Mouse = mouseStroke;
                stroke.Mouse.Flags = MouseFlags.MoveRelative;
                InterceptionDriver.Send(context, mouseId, ref stroke, 1);
            }
        }
        public void MoveMouseTo(int x, int y, int mouseId)
        {
            if (x != 0 | y != 0)
            {
                Stroke stroke = new Stroke();
                MouseStroke mouseStroke = new MouseStroke();
                mouseStroke.X = x;
                mouseStroke.Y = y;
                stroke.Mouse = mouseStroke;
                stroke.Mouse.Flags = MouseFlags.MoveAbsolute;
                InterceptionDriver.Send(context, mouseId, ref stroke, 1);
            }
        }
    }
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int Predicate(int device);
    [Flags]
    public enum KeyState : ushort
    {
        Down = 0x00,
        Up = 0x01,
        E0 = 0x02,
        E1 = 0x04,
        TermsrvSetLED = 0x08,
        TermsrvShadow = 0x10,
        TermsrvVKPacket = 0x20
    }
    [Flags]
    public enum KeyboardFilterMode : ushort
    {
        None = 0x0000,
        All = 0xFFFF,
        KeyDown = KeyState.Up,
        KeyUp = KeyState.Up << 1,
        KeyE0 = KeyState.E0 << 1,
        KeyE1 = KeyState.E1 << 1,
        KeyTermsrvSetLED = KeyState.TermsrvSetLED << 1,
        KeyTermsrvShadow = KeyState.TermsrvShadow << 1,
        KeyTermsrvVKPacket = KeyState.TermsrvVKPacket << 1
    }
    [Flags]
    public enum MouseState : ushort
    {
        LeftDown = 0x01,
        LeftUp = 0x02,
        RightDown = 0x04,
        RightUp = 0x08,
        MiddleDown = 0x10,
        MiddleUp = 0x20,
        LeftExtraDown = 0x40,
        LeftExtraUp = 0x80,
        RightExtraDown = 0x100,
        RightExtraUp = 0x200,
        ScrollVertical = 0x400,
        ScrollUp = 0x400,
        ScrollDown = 0x400,
        ScrollHorizontal = 0x800,
        ScrollLeft = 0x800,
        ScrollRight = 0x800,
    }
    [Flags]
    public enum MouseFilterMode : ushort
    {
        None = 0x0000,
        All = 0xFFFF,
        LeftDown = 0x01,
        LeftUp = 0x02,
        RightDown = 0x04,
        RightUp = 0x08,
        MiddleDown = 0x10,
        MiddleUp = 0x20,
        LeftExtraDown = 0x40,
        LeftExtraUp = 0x80,
        RightExtraDown = 0x100,
        RightExtraUp = 0x200,
        MouseWheelVertical = 0x400,
        MouseWheelHorizontal = 0x800,
        MouseMove = 0x1000,
    }
    [Flags]
    public enum MouseFlags : ushort
    {
        MoveRelative = 0x000,
        MoveAbsolute = 0x001,
        VirtualDesktop = 0x002,
        AttributesChanged = 0x004,
        MoveWithoutCoalescing = 0x008,
        TerminalServicesSourceShadow = 0x100
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseStroke
    {
        public MouseState State;
        public MouseFlags Flags;
        public Int16 Rolling;
        public Int32 X;
        public Int32 Y;
        public UInt16 Information;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyStroke
    {
        public Keys Code;
        public KeyState State;
        public UInt32 Information;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct Stroke
    {
        [FieldOffset(0)]
        public MouseStroke Mouse;
        [FieldOffset(0)]
        public KeyStroke Key;
    }
    public static class InterceptionDriver
    {
        [DllImport("interception.dll", EntryPoint = "interception_create_context", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateContext();
        [DllImport("interception.dll", EntryPoint = "interception_destroy_context", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DestroyContext(IntPtr context);
        [DllImport("interception.dll", EntryPoint = "interception_get_precedence", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetPrecedence(IntPtr context, Int32 device);
        [DllImport("interception.dll", EntryPoint = "interception_set_precedence", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPrecedence(IntPtr context, Int32 device, Int32 Precedence);
        [DllImport("interception.dll", EntryPoint = "interception_get_filter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void GetFilter(IntPtr context, Int32 device);
        [DllImport("interception.dll", EntryPoint = "interception_set_filter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetFilter(IntPtr context, Predicate predicate, Int32 keyboardFilterMode);
        [DllImport("interception.dll", EntryPoint = "interception_wait", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 Wait(IntPtr context);
        [DllImport("interception.dll", EntryPoint = "interception_wait_with_timeout", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 WaitWithTimeout(IntPtr context, UInt64 milliseconds);
        [DllImport("interception.dll", EntryPoint = "interception_send", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 Send(IntPtr context, Int32 device, ref Stroke stroke, UInt32 numStrokes);
        [DllImport("interception.dll", EntryPoint = "interception_receive", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 Receive(IntPtr context, Int32 device, ref Stroke stroke, UInt32 numStrokes);
        [DllImport("interception.dll", EntryPoint = "interception_get_hardware_id", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 GetHardwareId(IntPtr context, Int32 device, String hardwareIdentifier, UInt32 sizeOfString);
        [DllImport("interception.dll", EntryPoint = "interception_is_invalid", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 IsInvalid(Int32 device);
        [DllImport("interception.dll", EntryPoint = "interception_is_keyboard", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 IsKeyboard(Int32 device);
        [DllImport("interception.dll", EntryPoint = "interception_is_mouse", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 IsMouse(Int32 device);
    }
    public class KeyPressedEventArgs : EventArgs
    {
        public Keys Key { get; set; }
        public KeyState State { get; set; }
        public bool Handled { get; set; }
    }
    public enum Keys : ushort
    {
        CANCEL = 70,
        BACK = 14,
        TAB = 15,
        CLEAR = 76,
        RETURN = 28,
        SHIFT = 42,
        CONTROL = 29,
        MENU = 56,
        CAPITAL = 58,
        ESCAPE = 1,
        SPACE = 57,
        PRIOR = 73,
        NEXT = 81,
        END = 79,
        HOME = 71,
        LEFT = 101,
        UP = 100,
        RIGHT = 103,
        DOWN = 102,
        SNAPSHOT = 84,
        INSERT = 91,
        NUMPADDEL = 83,
        NUMPADINSERT = 82,
        HELP = 99,
        APOSTROPHE = 41,
        BACKSPACE = 14,
        PAGEDOWN = 97,
        PAGEUP = 93,
        FIN = 96,
        MOUSE = 105,
        A = 16,
        B = 48,
        C = 46,
        D = 32,
        E = 18,
        F = 33,
        G = 34,
        H = 35,
        I = 23,
        J = 36,
        K = 37,
        L = 38,
        M = 39,
        N = 49,
        O = 24,
        P = 25,
        Q = 30,
        R = 19,
        S = 31,
        T = 20,
        U = 22,
        V = 47,
        W = 44,
        X = 45,
        Y = 21,
        Z = 17,
        LWIN = 91,
        RWIN = 92,
        APPS = 93,
        DELETE = 95,
        NUMPAD0 = 82,
        NUMPAD1 = 79,
        NUMPAD2 = 80,
        NUMPAD3 = 81,
        NUMPAD4 = 75,
        NUMPAD5 = 76,
        NUMPAD6 = 77,
        NUMPAD7 = 71,
        NUMPAD8 = 72,
        NUMPAD9 = 73,
        MULTIPLY = 55,
        ADD = 78,
        SUBTRACT = 74,
        DECIMAL = 83,
        PRINTSCREEN = 84,
        DIVIDE = 53,
        F1 = 59,
        F2 = 60,
        F3 = 61,
        F4 = 62,
        F5 = 63,
        F6 = 64,
        F7 = 65,
        F8 = 66,
        F9 = 67,
        F10 = 68,
        F11 = 87,
        F12 = 88,
        NUMLOCK = 69,
        SCROLLLOCK = 70,
        LEFTSHIFT = 42,
        RIGHTSHIFT = 54,
        LEFTCONTROL = 29,
        RIGHTCONTROL = 99,
        LEFTALT = 56,
        RIGHTALT = 98,
        BROWSER_BACK = 106,
        BROWSER_FORWARD = 105,
        BROWSER_REFRESH = 103,
        BROWSER_STOP = 104,
        BROWSER_SEARCH = 101,
        BROWSER_FAVORITES = 102,
        BROWSER_HOME = 50,
        VOLUME_MUTE = 32,
        VOLUME_DOWN = 46,
        VOLUME_UP = 48,
        MEDIA_NEXT_TRACK = 25,
        MEDIA_PREV_TRACK = 16,
        MEDIA_STOP = 36,
        MEDIA_PLAY_PAUSE = 34,
        LAUNCH_MAIL = 108,
        LAUNCH_MEDIA_SELECT = 109,
        LAUNCH_APP1 = 107,
        LAUNCH_APP2 = 33,
        OEM_1 = 27,
        OEM_PLUS = 13,
        OEM_COMMA = 50,
        OEM_MINUS = 0,
        OEM_PERIOD = 51,
        OEM_2 = 52,
        OEM_3 = 40,
        OEM_4 = 12,
        OEM_5 = 43,
        OEM_6 = 26,
        OEM_7 = 41,
        OEM_8 = 53,
        OEM_102 = 86,
        EREOF = 93,
        ZOOM = 98,
        Escape = 1,
        One = 2,
        Two = 3,
        Three = 4,
        Four = 5,
        Five = 6,
        Six = 7,
        Seven = 8,
        Eight = 9,
        Nine = 10,
        Zero = 11,
        DashUnderscore = 12,
        PlusEquals = 13,
        Backspace = 14,
        Tab = 15,
        OpenBracketBrace = 26,
        CloseBracketBrace = 27,
        Enter = 28,
        Control = 29,
        SemicolonColon = 39,
        SingleDoubleQuote = 40,
        Tilde = 41,
        LeftShift = 42,
        BackslashPipe = 43,
        CommaLeftArrow = 51,
        PeriodRightArrow = 52,
        ForwardSlashQuestionMark = 53,
        RightShift = 54,
        RightAlt = 56,
        Space = 57,
        CapsLock = 58,
        Up = 72,
        Down = 80,
        Right = 77,
        Left = 75,
        Home = 71,
        End = 79,
        Delete = 83,
        PageUp = 73,
        PageDown = 81,
        Insert = 82,
        PrintScreen = 55,
        NumLock = 69,
        ScrollLock = 70,
        Menu = 93,
        WindowsKey = 91,
        NumpadDivide = 53,
        NumpadAsterisk = 55,
        Numpad7 = 71,
        Numpad8 = 72,
        Numpad9 = 73,
        Numpad4 = 75,
        Numpad5 = 76,
        Numpad6 = 77,
        Numpad1 = 79,
        Numpad2 = 80,
        Numpad3 = 81,
        Numpad0 = 82,
        NumpadDelete = 83,
        NumpadEnter = 28,
        NumpadPlus = 78,
        NumpadMinus = 74,
    }
    public class MousePressedEventArgs : EventArgs
    {
        public MouseState State { get; set; }
        public bool Handled { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public short Rolling { get; set; }
    }
    public enum ScrollDirection
    {
        Down,
        Up
    }
}