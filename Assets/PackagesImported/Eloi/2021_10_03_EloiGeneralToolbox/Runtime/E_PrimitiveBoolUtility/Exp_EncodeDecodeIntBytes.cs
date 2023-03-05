using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp_EncodeDecodeIntBytes : MonoBehaviour
{
    public int myInt;
    public byte myByte1;
    public byte myByte2;
    public byte myByte3;
    public byte myByte4;
    public int myInt2;

    [Header("Booleen Switch")]
    public int    intFromBool;
    public bool[] intAsBool = new bool[32];
    public bool[] intAsBool2 = new bool[32];

    [Header("Booleen Switch")]
    public byte byteFromBool;
    public bool[] byteAsBool = new bool[8];
    public bool[] byteAsBool2 = new bool[8];

    [Header("Booleen Switch")]
    public long longFromBool;
    public byte[] longAsBool = new byte[8];
    public long longFromBool2;

    public void OnValidate()
    {
        E_PrimitiveBoolUtility.IntToFourBytes(in myInt, out myByte1, out myByte2, out myByte3, out myByte4);
        E_PrimitiveBoolUtility.FourBytesToInt(in myByte1, in myByte2, in myByte3, in myByte4, out myInt2);

        for (int i = 0; i < 32; i++)
        {
            E_PrimitiveBoolUtility.SetBit(ref intFromBool, in i, in intAsBool[i]);
            intAsBool2[i]= E_PrimitiveBoolUtility.GetBit(in intFromBool, in i);
        }
        for (int i = 0; i < 8; i++)
        {
            E_PrimitiveBoolUtility.Set(ref byteFromBool, in i, in byteAsBool[i]);
            byteAsBool2[i] = E_PrimitiveBoolUtility.GetBit(in byteFromBool, in i);
        }

        E_PrimitiveBoolUtility.LongToEightBytes(
            in longFromBool, 
            out longAsBool[0],
            out longAsBool[1],
            out longAsBool[2],
            out longAsBool[3],
            out longAsBool[4],
            out longAsBool[5], 
            out longAsBool[6],
            out longAsBool[7]);
        E_PrimitiveBoolUtility.EightBytesToLong(
            in longAsBool[0],
            in longAsBool[1],
            in longAsBool[2],
            in longAsBool[3],
            in longAsBool[4],
            in longAsBool[5],
            in longAsBool[6],
            in longAsBool[7],
            out longFromBool2);


    }


}
