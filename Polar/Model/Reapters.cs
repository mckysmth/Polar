using System;
namespace Polar.Model
{
    [Flags]
    enum Repeater : byte
    {
        None = 0,
        Sunday = 0b0000_0001,    // 1
        Monday = 0b0000_0010,    // 2
        Tuesday = 0b0000_0100,   // 4
        Wednesday = 0b0000_1000, // 8
        Thursday = 0b0001_0000,  // 16
        Friday = 0b0010_0000,    // 32
        Saturday = 0b0100_0000,  // 64
        Monthly = 0b1000_0000,   // 128
        Weekly = 0b1000_0001,    // 129
        Everyday = Sunday | Monday | Tuesday | Wednesday | Thursday | Friday | Saturday
    }
}
