using System.Collections.Generic;
using UnityEngine;

public static class ColorfulMC
{
    private static readonly Vector3[] n = new Vector3[]
    {
            new Vector3(0.6f, 0.6f, 0.6f),
            new Vector3(0.6f, 0.6f, -0.6f),
            new Vector3(0.7f, 0.7f, 0f),
            new Vector3(-0.6f, 0.6f, -0.6f),
            new Vector3(-0.6f, 0.6f, 0.6f),
            new Vector3(0f, 0.7f, -0.7f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 0.7f, 0.7f),
            new Vector3(-0.7f, 0.7f, 0f),
            new Vector3(0.6f, -0.6f, 0.6f),
            new Vector3(0.7f, 0f, 0.7f),
            new Vector3(0.6f, -0.6f, -0.6f),
            new Vector3(1f, 0f, 0f),
            new Vector3(0.9f, 0f, -0.4f),
            new Vector3(-0.4f, 0f, 0.9f),
            new Vector3(0.3f, 0.9f, 0.3f),
            new Vector3(0f, 0.9f, 0.4f),
            new Vector3(0f, -0.4f, -0.9f),
            new Vector3(0.9f, 0.3f, -0.3f),
            new Vector3(0.7f, 0f, -0.7f),
            new Vector3(-0.6f, -0.6f, 0.6f),
            new Vector3(0f, 0f, 1f),
            new Vector3(-0.6f, -0.6f, -0.6f),
            new Vector3(-0.9f, -0.4f, 0f),
            new Vector3(0.4f, 0.9f, 0f),
            new Vector3(-0.3f, 0.3f, 0.9f),
            new Vector3(-0.7f, 0f, 0.7f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, -0.4f, 0.9f),
            new Vector3(0f, 0.9f, -0.4f),
            new Vector3(0.9f, 0.3f, 0.3f),
            new Vector3(-0.4f, 0f, -0.9f),
            new Vector3(0.9f, 0f, 0.4f),
            new Vector3(0.3f, 0.9f, -0.3f),
            new Vector3(-0.3f, 0.3f, -0.9f),
            new Vector3(0.7f, -0.7f, 0f),
            new Vector3(-0.4f, -0.9f, 0f),
            new Vector3(0.9f, 0.4f, 0f),
            new Vector3(0.3f, -0.3f, -0.9f),
            new Vector3(0f, -0.7f, -0.7f),
            new Vector3(0.3f, -0.3f, 0.9f),
            new Vector3(0f, -0.7f, 0.7f),
            new Vector3(-0.7f, -0.7f, 0f),
            new Vector3(0.9f, -0.4f, 0f),
            new Vector3(-0.4f, 0.9f, 0f),
            new Vector3(0.3f, 0.3f, -0.9f),
            new Vector3(-0.7f, 0f, -0.7f),
            new Vector3(-0.9f, 0f, 0.4f),
            new Vector3(0.4f, 0f, -0.9f),
            new Vector3(-0.3f, 0.9f, -0.3f),
            new Vector3(-0.9f, 0.3f, 0.3f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(0.3f, -0.9f, 0.3f),
            new Vector3(-0.3f, -0.9f, -0.3f),
            new Vector3(0f, 0.4f, -0.9f),
            new Vector3(0f, -0.9f, 0.4f),
            new Vector3(0.9f, -0.3f, -0.3f),
            new Vector3(-0.9f, -0.3f, -0.3f),
            new Vector3(0f, -1f, 0f),
            new Vector3(0.3f, 0.3f, 0.9f),
            new Vector3(-0.9f, 0.3f, -0.3f),
            new Vector3(0.4f, 0f, 0.9f),
            new Vector3(-0.9f, 0f, -0.4f),
            new Vector3(-0.3f, 0.9f, 0.3f),
            new Vector3(0f, -0.9f, -0.4f),
            new Vector3(0f, 0.4f, 0.9f),
            new Vector3(0.9f, -0.3f, 0.3f),
            new Vector3(-0.9f, -0.3f, 0.3f),
            new Vector3(0.3f, -0.9f, -0.3f),
            new Vector3(-0.3f, -0.9f, 0.3f),
            new Vector3(0.4f, -0.9f, 0f),
            new Vector3(-0.9f, 0.4f, 0f),
            new Vector3(-0.3f, -0.3f, 0.9f),
            new Vector3(-0.3f, -0.3f, -0.9f)
};
    private static readonly Vector3[] v = new Vector3[]
    {
             new Vector3(-0.5f, -0.5f, 0f),
             new Vector3(0f, -0.5f, -0.5f),
             new Vector3(-0.5f, 0f, -0.5f),
             new Vector3(-0.5f, 0f, 0.5f),
             new Vector3(0f, -0.5f, 0.5f),
             new Vector3(0f, -0.5f, 0f),
             new Vector3(-0.5f, 0f, 0f),
             new Vector3(0.5f, 0f, 0.5f),
             new Vector3(0.5f, -0.5f, 0f),
             new Vector3(0.25f, -0.5f, -0.25f),
             new Vector3(0f, 0f, 0f),
             new Vector3(-0.25f, -0.5f, 0.25f),
             new Vector3(0f, 0f, 0.5f),
             new Vector3(0.5f, 0f, -0.5f),
             new Vector3(0f, 0f, -0.5f),
             new Vector3(-0.25f, -0.5f, -0.25f),
             new Vector3(0.25f, -0.5f, 0.25f),
             new Vector3(0.5f, 0f, 0f),
             new Vector3(-0.5f, 0.5f, 0f),
             new Vector3(0f, 0.5f, -0.5f),
             new Vector3(-0.5f, 0.25f, 0.25f),
             new Vector3(-0.5f, -0.25f, -0.25f),
             new Vector3(0.2f, 0f, -0.09999996f),
             new Vector3(0.25f, -0.25f, 0f),
             new Vector3(0f, -0.25f, 0.25f),
             new Vector3(-0.09999996f, 0f, 0.2f),
             new Vector3(0.25f, 0.25f, 0f),
             new Vector3(0f, 0.25f, 0.25f),
             new Vector3(0f, 0.2f, 0.09999996f),
             new Vector3(-0.25f, 0.25f, 0f),
             new Vector3(-0.25f, 0f, -0.25f),
             new Vector3(0f, -0.09999996f, -0.2f),
             new Vector3(0.25f, 0f, -0.25f),
             new Vector3(-0.125f, 0.125f, 0f),
             new Vector3(0.25f, 0.25f, -0.5f),
             new Vector3(-0.25f, -0.25f, -0.5f),
             new Vector3(-0.3333333f, -0.3333333f, -0.3333333f),
             new Vector3(-0.2f, -0.09999996f, 0f),
             new Vector3(0f, 0.25f, -0.25f),
             new Vector3(0.09999996f, 0.2f, 0f),
             new Vector3(-0.25f, 0f, 0.25f),
             new Vector3(0f, 0.125f, -0.125f),
             new Vector3(-0.125f, 0.25f, -0.125f),
             new Vector3(0f, 0.5f, 0.5f),
             new Vector3(-0.5f, 0.25f, -0.25f),
             new Vector3(-0.5f, -0.25f, 0.25f),
             new Vector3(0.25f, 0.25f, 0.5f),
             new Vector3(-0.25f, -0.25f, 0.5f),
             new Vector3(-0.3333333f, -0.3333333f, 0.3333333f),
             new Vector3(0f, -0.09999996f, 0.2f),
             new Vector3(0f, 0.2f, -0.09999996f),
             new Vector3(0.25f, 0f, 0.25f),
             new Vector3(-0.09999996f, 0f, -0.2f),
             new Vector3(0f, -0.25f, -0.25f),
             new Vector3(0.2f, 0f, 0.09999996f),
             new Vector3(-0.125f, 0.25f, 0.125f),
             new Vector3(0f, -0.125f, -0.125f),
             new Vector3(0f, 0.5f, 0f),
             new Vector3(-0.09999996f, -0.2f, 0f),
             new Vector3(0.2f, 0.09999996f, 0f),
             new Vector3(-0.3333333f, -0.3333333f, 0.3333333f),
             new Vector3(0.25f, -0.125f, 0.125f),
             new Vector3(0.125f, 0f, 0.125f),
             new Vector3(0.125f, 0f, -0.125f),
             new Vector3(0.25f, -0.125f, -0.125f),
             new Vector3(-0.25f, -0.25f, 0f),
             new Vector3(-0.3333333f, -0.3333333f, 0.3333333f),
             new Vector3(-0.3333333f, -0.3333333f, -0.3333333f),
             new Vector3(0.5f, 0.5f, 0f),
             new Vector3(0.25f, -0.25f, 0.5f),
             new Vector3(-0.25f, 0.25f, 0.5f),
             new Vector3(0.2f, -0.09999996f, 0f),
             new Vector3(-0.09999996f, 0.2f, 0f),
             new Vector3(-0.2f, 0f, 0.09999996f),
             new Vector3(0.09999996f, 0f, -0.2f),
             new Vector3(0.5f, 0.25f, -0.25f),
             new Vector3(0.5f, -0.25f, 0.25f),
             new Vector3(0.3333333f, -0.3333333f, 0.3333333f),
             new Vector3(0.125f, 0.25f, 0.125f),
             new Vector3(0.125f, 0.125f, 0f),
             new Vector3(0.25f, 0.5f, -0.25f),
             new Vector3(-0.25f, 0.5f, 0.25f),
             new Vector3(-0.3333333f, 0.3333333f, 0.3333333f),
             new Vector3(0.25f, 0.125f, 0.125f),
             new Vector3(-0.125f, 0.125f, -0.25f),
             new Vector3(-0.3333333f, 0.3333333f, 0.3333333f),
             new Vector3(0.3333333f, 0.3333333f, -0.3333333f),
             new Vector3(0.3333333f, 0.3333333f, -0.3333333f),
             new Vector3(0.125f, 0.125f, 0.25f),
             new Vector3(0.3333333f, 0.3333333f, -0.3333333f),
             new Vector3(-0.3333333f, 0.3333333f, 0.3333333f),
             new Vector3(0.3333333f, -0.3333333f, 0.3333333f),
             new Vector3(-0.25f, 0.125f, -0.125f),
             new Vector3(0f, 0.09999996f, -0.2f),
             new Vector3(0f, -0.2f, 0.09999996f),
             new Vector3(-0.125f, -0.125f, -0.25f),
             new Vector3(0.125f, -0.125f, -0.25f),
             new Vector3(0.3333333f, -0.3333333f, 0.3333333f),
             new Vector3(0.125f, -0.25f, -0.125f),
             new Vector3(-0.3333333f, -0.3333333f, -0.3333333f),
             new Vector3(-0.25f, 0.25f, -0.5f),
             new Vector3(0.25f, -0.25f, -0.5f),
             new Vector3(0.5f, -0.25f, -0.25f),
             new Vector3(0.5f, 0.25f, 0.25f),
             new Vector3(0.3333333f, -0.3333333f, -0.3333333f),
             new Vector3(0.125f, 0.25f, -0.125f),
             new Vector3(0.09999996f, 0f, 0.2f),
             new Vector3(-0.2f, 0f, -0.09999996f),
             new Vector3(0f, -0.2f, -0.09999996f),
             new Vector3(0f, 0.09999996f, 0.2f),
             new Vector3(0.3333333f, -0.3333333f, -0.3333333f),
             new Vector3(0.125f, -0.125f, 0.25f),
             new Vector3(0.3333333f, -0.3333333f, -0.3333333f),
             new Vector3(-0.125f, -0.125f, 0.25f),
             new Vector3(0.25f, 0.5f, 0.25f),
             new Vector3(-0.25f, 0.5f, -0.25f),
             new Vector3(-0.3333333f, 0.3333333f, -0.3333333f),
             new Vector3(0.25f, 0.125f, -0.125f),
             new Vector3(0.3333333f, 0.3333333f, 0.3333333f),
             new Vector3(-0.3333333f, 0.3333333f, -0.3333333f),
             new Vector3(0.125f, 0.125f, -0.25f),
             new Vector3(-0.3333333f, 0.3333333f, -0.3333333f),
             new Vector3(0.3333333f, 0.3333333f, 0.3333333f),
             new Vector3(-0.125f, 0.125f, 0.25f),
             new Vector3(-0.25f, 0.125f, 0.125f),
             new Vector3(0.3333333f, 0.3333333f, 0.3333333f),
             new Vector3(0.125f, -0.25f, 0.125f),
             new Vector3(0.09999996f, -0.2f, 0f),
             new Vector3(-0.2f, 0.09999996f, 0f),
             new Vector3(-0.25f, -0.125f, -0.125f),
             new Vector3(-0.25f, -0.125f, 0.125f),
             new Vector3(-0.125f, -0.25f, 0.125f),
             new Vector3(-0.125f, -0.25f, -0.125f)
    };
    private static readonly Dictionary<int, Vector3[]>[] vertexTable = new Dictionary<int, Vector3[]>[]
    {
            new Dictionary<int, Vector3[]>(),
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[1],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[3],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[5],v[6],v[6],v[3],v[4] }},
                { 0, new Vector3[] {v[5],v[1],v[2],v[2],v[6],v[5] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[7],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[8],v[9],v[10],v[10],v[7],v[8],v[11],v[4],v[7],v[7],v[10],v[11] }},
                { 0, new Vector3[] {v[9],v[1],v[2],v[2],v[10],v[9],v[0],v[11],v[10],v[10],v[2],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[12],v[5],v[5],v[0],v[3] }},
                { 2, new Vector3[] {v[12],v[7],v[8],v[8],v[5],v[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[8],v[9],v[10],v[10],v[7],v[8],v[7],v[10],v[12] }},
                { 0, new Vector3[] {v[9],v[1],v[2],v[2],v[10],v[9],v[2],v[6],v[10] }},
                { 1, new Vector3[] {v[3],v[12],v[10],v[10],v[6],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[1],v[8],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[5],v[14],v[14],v[2],v[0] }},
                { 3, new Vector3[] {v[5],v[8],v[13],v[13],v[14],v[5] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[1],v[15],v[10],v[10],v[13],v[1],v[16],v[8],v[13],v[13],v[10],v[16] }},
                { 1, new Vector3[] {v[15],v[0],v[3],v[3],v[10],v[15],v[4],v[16],v[10],v[10],v[3],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[16],v[10],v[10],v[3],v[4],v[3],v[10],v[6] }},
                { 3, new Vector3[] {v[16],v[8],v[13],v[13],v[10],v[16],v[13],v[14],v[10] }},
                { 0, new Vector3[] {v[2],v[6],v[10],v[10],v[14],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[1],v[5],v[17],v[17],v[13],v[1] }},
                { 2, new Vector3[] {v[5],v[4],v[7],v[7],v[17],v[5] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[11],v[10],v[10],v[2],v[0],v[2],v[10],v[14] }},
                { 2, new Vector3[] {v[11],v[4],v[7],v[7],v[10],v[11],v[7],v[17],v[10] }},
                { 3, new Vector3[] {v[13],v[14],v[10],v[10],v[17],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[1],v[15],v[10],v[10],v[13],v[1],v[13],v[10],v[17] }},
                { 1, new Vector3[] {v[15],v[0],v[3],v[3],v[10],v[15],v[3],v[12],v[10] }},
                { 2, new Vector3[] {v[7],v[17],v[10],v[10],v[12],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[12],v[10],v[10],v[6],v[3] }},
                { 2, new Vector3[] {v[7],v[17],v[10],v[10],v[12],v[7] }},
                { 0, new Vector3[] {v[2],v[6],v[10],v[10],v[14],v[2] }},
                { 3, new Vector3[] {v[13],v[14],v[10],v[10],v[17],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[18],v[2],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[18],v[6],v[14],v[14],v[19],v[18] }},
                { 0, new Vector3[] {v[6],v[0],v[1],v[1],v[14],v[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[18],v[20],v[10],v[10],v[19],v[18],v[21],v[2],v[19],v[19],v[10],v[21] }},
                { 1, new Vector3[] {v[20],v[3],v[4],v[4],v[10],v[20],v[0],v[21],v[10],v[10],v[4],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[18],v[20],v[10],v[10],v[19],v[18],v[19],v[10],v[14] }},
                { 1, new Vector3[] {v[20],v[3],v[4],v[4],v[10],v[20],v[4],v[5],v[10] }},
                { 0, new Vector3[] {v[1],v[14],v[10],v[10],v[5],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[7],v[8] }},
                { 4, new Vector3[] {v[2],v[19],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[1],v[14],v[22],v[22],v[23],v[1],v[1],v[23],v[9],v[0],v[11],v[24],v[0],v[24],v[25],v[25],v[6],v[0] }},
                { 4, new Vector3[] {v[19],v[26],v[22],v[22],v[14],v[19],v[19],v[18],v[27],v[27],v[26],v[19],v[18],v[6],v[25],v[25],v[27],v[18] }},
                { 2, new Vector3[] {v[7],v[23],v[22],v[22],v[26],v[7],v[7],v[8],v[9],v[9],v[23],v[7],v[7],v[26],v[27],v[4],v[7],v[24],v[24],v[11],v[4],v[7],v[27],v[25],v[25],v[24],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[12],v[28],v[28],v[29],v[3],v[3],v[29],v[20],v[0],v[21],v[30],v[0],v[30],v[31],v[31],v[5],v[0] }},
                { 2, new Vector3[] {v[7],v[26],v[28],v[28],v[12],v[7],v[7],v[8],v[32],v[32],v[26],v[7],v[8],v[5],v[31],v[31],v[32],v[8] }},
                { 4, new Vector3[] {v[19],v[29],v[28],v[28],v[26],v[19],v[19],v[18],v[20],v[20],v[29],v[19],v[19],v[26],v[32],v[2],v[19],v[30],v[30],v[21],v[2],v[19],v[32],v[31],v[31],v[30],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[7],v[8],v[24],v[24],v[12],v[7],v[8],v[32],v[33],v[33],v[24],v[8],v[8],v[9],v[32] }},
                { 1, new Vector3[] {v[3],v[12],v[24],v[3],v[24],v[33],v[33],v[20],v[3] }},
                { 4, new Vector3[] {v[19],v[18],v[20],v[20],v[32],v[19],v[19],v[32],v[14] }},
                { 0, new Vector3[] {v[1],v[14],v[32],v[32],v[9],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[13],v[34],v[10],v[10],v[8],v[13],v[35],v[1],v[8],v[8],v[10],v[35] }},
                { 4, new Vector3[] {v[34],v[19],v[18],v[18],v[10],v[34],v[2],v[35],v[10],v[10],v[18],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[13],v[34],v[10],v[10],v[8],v[13],v[8],v[10],v[5] }},
                { 4, new Vector3[] {v[34],v[19],v[18],v[18],v[10],v[34],v[18],v[6],v[10] }},
                { 0, new Vector3[] {v[0],v[5],v[10],v[10],v[6],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[34],v[19],v[10],v[19],v[18],v[10],v[18],v[20],v[10],v[2],v[35],v[36],v[36],v[21],v[2] }},
                { 1, new Vector3[] {v[20],v[3],v[10],v[3],v[4],v[10],v[4],v[16],v[10],v[0],v[21],v[36],v[36],v[15],v[0] }},
                { 3, new Vector3[] {v[16],v[8],v[10],v[8],v[13],v[10],v[13],v[34],v[10],v[1],v[15],v[36],v[36],v[35],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[34],v[19],v[10],v[19],v[18],v[10],v[18],v[20],v[10] }},
                { 1, new Vector3[] {v[20],v[3],v[10],v[3],v[4],v[10],v[4],v[16],v[10] }},
                { 3, new Vector3[] {v[16],v[8],v[10],v[8],v[13],v[10],v[13],v[34],v[10] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[1],v[5],v[37],v[37],v[30],v[1],v[1],v[30],v[35],v[13],v[34],v[38],v[13],v[38],v[39],v[39],v[17],v[13] }},
                { 2, new Vector3[] {v[4],v[40],v[37],v[37],v[5],v[4],v[4],v[7],v[27],v[27],v[40],v[4],v[7],v[17],v[39],v[39],v[27],v[7] }},
                { 4, new Vector3[] {v[18],v[30],v[37],v[37],v[40],v[18],v[18],v[2],v[35],v[35],v[30],v[18],v[18],v[40],v[27],v[19],v[18],v[38],v[38],v[34],v[19],v[18],v[27],v[39],v[39],v[38],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[7],v[17],v[17],v[23],v[4],v[4],v[23],v[41],v[41],v[40],v[4],v[4],v[40],v[11] }},
                { 3, new Vector3[] {v[13],v[23],v[17],v[13],v[34],v[41],v[41],v[23],v[13] }},
                { 4, new Vector3[] {v[19],v[18],v[40],v[40],v[34],v[19],v[18],v[6],v[40] }},
                { 0, new Vector3[] {v[0],v[11],v[40],v[40],v[6],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[21],v[36],v[36],v[15],v[0],v[3],v[10],v[42],v[42],v[20],v[3],v[3],v[12],v[10] }},
                { 4, new Vector3[] {v[2],v[35],v[36],v[36],v[21],v[2],v[19],v[18],v[20],v[20],v[34],v[19] }},
                { 3, new Vector3[] {v[1],v[15],v[36],v[36],v[35],v[1],v[13],v[34],v[42],v[42],v[10],v[13],v[13],v[10],v[17] }},
                { 2, new Vector3[] {v[7],v[17],v[10],v[10],v[12],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[19],v[18],v[20],v[20],v[34],v[19] }},
                { 3, new Vector3[] {v[13],v[34],v[42],v[42],v[10],v[13],v[13],v[10],v[17] }},
                { 1, new Vector3[] {v[3],v[10],v[42],v[42],v[20],v[3],v[3],v[12],v[10] }},
                { 2, new Vector3[] {v[7],v[17],v[10],v[10],v[12],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[18],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[2],v[44],v[10],v[10],v[1],v[2],v[45],v[0],v[1],v[1],v[10],v[45] }},
                { 5, new Vector3[] {v[44],v[18],v[43],v[43],v[10],v[44],v[3],v[45],v[10],v[10],v[43],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[6],v[12],v[12],v[4],v[0] }},
                { 5, new Vector3[] {v[6],v[18],v[43],v[43],v[12],v[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[2],v[44],v[10],v[10],v[1],v[2],v[1],v[10],v[5] }},
                { 5, new Vector3[] {v[44],v[18],v[43],v[43],v[10],v[44],v[43],v[12],v[10] }},
                { 1, new Vector3[] {v[4],v[5],v[10],v[10],v[12],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[43],v[46],v[10],v[10],v[18],v[43],v[47],v[3],v[18],v[18],v[10],v[47] }},
                { 2, new Vector3[] {v[46],v[7],v[8],v[8],v[10],v[46],v[4],v[47],v[10],v[10],v[8],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[46],v[7],v[10],v[7],v[8],v[10],v[8],v[9],v[10],v[4],v[47],v[48],v[48],v[11],v[4] }},
                { 0, new Vector3[] {v[9],v[1],v[10],v[1],v[2],v[10],v[2],v[44],v[10],v[0],v[11],v[48],v[48],v[45],v[0] }},
                { 5, new Vector3[] {v[44],v[18],v[10],v[18],v[43],v[10],v[43],v[46],v[10],v[3],v[45],v[48],v[48],v[47],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[43],v[46],v[10],v[10],v[18],v[43],v[18],v[10],v[6] }},
                { 2, new Vector3[] {v[46],v[7],v[8],v[8],v[10],v[46],v[8],v[5],v[10] }},
                { 1, new Vector3[] {v[0],v[6],v[10],v[10],v[5],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[46],v[7],v[10],v[7],v[8],v[10],v[8],v[9],v[10] }},
                { 0, new Vector3[] {v[9],v[1],v[10],v[1],v[2],v[10],v[2],v[44],v[10] }},
                { 5, new Vector3[] {v[44],v[18],v[10],v[18],v[43],v[10],v[43],v[46],v[10] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[18],v[43] }},
                { 3, new Vector3[] {v[8],v[13],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[5],v[49],v[49],v[40],v[0],v[0],v[40],v[45],v[2],v[44],v[29],v[2],v[29],v[50],v[50],v[14],v[2] }},
                { 3, new Vector3[] {v[8],v[51],v[49],v[49],v[5],v[8],v[8],v[13],v[26],v[26],v[51],v[8],v[13],v[14],v[50],v[50],v[26],v[13] }},
                { 5, new Vector3[] {v[43],v[40],v[49],v[49],v[51],v[43],v[43],v[3],v[45],v[45],v[40],v[43],v[43],v[51],v[26],v[18],v[43],v[29],v[29],v[44],v[18],v[43],v[26],v[50],v[50],v[29],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[6],v[52],v[52],v[53],v[0],v[0],v[53],v[15],v[4],v[16],v[23],v[4],v[23],v[54],v[54],v[12],v[4] }},
                { 5, new Vector3[] {v[18],v[38],v[52],v[52],v[6],v[18],v[18],v[43],v[26],v[26],v[38],v[18],v[43],v[12],v[54],v[54],v[26],v[43] }},
                { 3, new Vector3[] {v[13],v[53],v[52],v[52],v[38],v[13],v[13],v[1],v[15],v[15],v[53],v[13],v[13],v[38],v[26],v[8],v[13],v[23],v[23],v[16],v[8],v[13],v[26],v[54],v[54],v[23],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[8],v[51],v[16],v[8],v[53],v[33],v[33],v[51],v[8],v[8],v[13],v[14],v[14],v[53],v[8] }},
                { 5, new Vector3[] {v[43],v[12],v[51],v[18],v[43],v[51],v[51],v[44],v[18] }},
                { 1, new Vector3[] {v[4],v[16],v[51],v[51],v[12],v[4] }},
                { 0, new Vector3[] {v[2],v[44],v[33],v[33],v[53],v[2],v[2],v[53],v[14] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[7],v[17],v[39],v[39],v[27],v[7],v[7],v[27],v[46],v[4],v[47],v[40],v[4],v[40],v[37],v[37],v[5],v[4] }},
                { 3, new Vector3[] {v[13],v[38],v[39],v[39],v[17],v[13],v[13],v[1],v[30],v[30],v[38],v[13],v[1],v[5],v[37],v[37],v[30],v[1] }},
                { 5, new Vector3[] {v[18],v[27],v[39],v[39],v[38],v[18],v[18],v[43],v[46],v[46],v[27],v[18],v[18],v[38],v[30],v[3],v[18],v[40],v[40],v[47],v[3],v[18],v[30],v[37],v[37],v[40],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[11],v[48],v[48],v[45],v[0],v[2],v[44],v[55],v[55],v[10],v[2],v[2],v[10],v[14] }},
                { 2, new Vector3[] {v[4],v[47],v[48],v[48],v[11],v[4],v[7],v[10],v[55],v[55],v[46],v[7],v[7],v[17],v[10] }},
                { 5, new Vector3[] {v[3],v[45],v[48],v[48],v[47],v[3],v[18],v[43],v[46],v[46],v[44],v[18] }},
                { 3, new Vector3[] {v[13],v[14],v[10],v[10],v[17],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[18],v[43],v[40],v[40],v[6],v[18],v[43],v[26],v[56],v[56],v[40],v[43],v[43],v[46],v[26] }},
                { 1, new Vector3[] {v[0],v[6],v[40],v[0],v[40],v[56],v[56],v[15],v[0] }},
                { 3, new Vector3[] {v[13],v[1],v[15],v[15],v[26],v[13],v[13],v[26],v[17] }},
                { 2, new Vector3[] {v[7],v[17],v[26],v[26],v[46],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[18],v[43],v[46],v[46],v[44],v[18] }},
                { 0, new Vector3[] {v[2],v[44],v[55],v[55],v[10],v[2],v[2],v[10],v[14] }},
                { 2, new Vector3[] {v[7],v[10],v[55],v[55],v[46],v[7],v[7],v[17],v[10] }},
                { 3, new Vector3[] {v[13],v[14],v[10],v[10],v[17],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[6],v[57],v[57],v[43],v[3] }},
                { 4, new Vector3[] {v[6],v[2],v[19],v[19],v[57],v[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[45],v[10],v[10],v[43],v[3],v[43],v[10],v[57] }},
                { 0, new Vector3[] {v[45],v[0],v[1],v[1],v[10],v[45],v[1],v[14],v[10] }},
                { 4, new Vector3[] {v[19],v[57],v[10],v[10],v[14],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[21],v[10],v[10],v[4],v[0],v[4],v[10],v[12] }},
                { 4, new Vector3[] {v[21],v[2],v[19],v[19],v[10],v[21],v[19],v[57],v[10] }},
                { 5, new Vector3[] {v[43],v[12],v[10],v[10],v[57],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[5],v[10],v[10],v[12],v[4] }},
                { 0, new Vector3[] {v[1],v[14],v[10],v[10],v[5],v[1] }},
                { 5, new Vector3[] {v[43],v[12],v[10],v[10],v[57],v[43] }},
                { 4, new Vector3[] {v[19],v[57],v[10],v[10],v[14],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[6],v[58],v[58],v[24],v[3],v[3],v[24],v[47],v[43],v[46],v[51],v[43],v[51],v[59],v[59],v[57],v[43] }},
                { 4, new Vector3[] {v[2],v[53],v[58],v[58],v[6],v[2],v[2],v[19],v[32],v[32],v[53],v[2],v[19],v[57],v[59],v[59],v[32],v[19] }},
                { 2, new Vector3[] {v[8],v[24],v[58],v[58],v[53],v[8],v[8],v[4],v[47],v[47],v[24],v[8],v[8],v[53],v[32],v[7],v[8],v[51],v[51],v[46],v[7],v[8],v[32],v[59],v[59],v[51],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[45],v[60],v[60],v[47],v[3],v[43],v[46],v[61],v[61],v[10],v[43],v[43],v[10],v[57] }},
                { 0, new Vector3[] {v[0],v[11],v[60],v[60],v[45],v[0],v[1],v[10],v[61],v[61],v[9],v[1],v[1],v[14],v[10] }},
                { 2, new Vector3[] {v[4],v[47],v[60],v[60],v[11],v[4],v[7],v[8],v[9],v[9],v[46],v[7] }},
                { 4, new Vector3[] {v[19],v[57],v[10],v[10],v[14],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[2],v[53],v[21],v[2],v[29],v[62],v[62],v[53],v[2],v[2],v[19],v[57],v[57],v[29],v[2] }},
                { 2, new Vector3[] {v[8],v[5],v[53],v[7],v[8],v[53],v[53],v[46],v[7] }},
                { 1, new Vector3[] {v[0],v[21],v[53],v[53],v[5],v[0] }},
                { 5, new Vector3[] {v[43],v[46],v[62],v[62],v[29],v[43],v[43],v[29],v[57] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[7],v[8],v[9],v[9],v[46],v[7] }},
                { 5, new Vector3[] {v[43],v[46],v[61],v[61],v[10],v[43],v[43],v[10],v[57] }},
                { 0, new Vector3[] {v[1],v[10],v[61],v[61],v[9],v[1],v[1],v[14],v[10] }},
                { 4, new Vector3[] {v[19],v[57],v[10],v[10],v[14],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[19],v[57],v[59],v[59],v[32],v[19],v[19],v[32],v[34],v[2],v[35],v[53],v[2],v[53],v[58],v[58],v[6],v[2] }},
                { 5, new Vector3[] {v[43],v[51],v[59],v[59],v[57],v[43],v[43],v[3],v[24],v[24],v[51],v[43],v[3],v[6],v[58],v[58],v[24],v[3] }},
                { 3, new Vector3[] {v[8],v[32],v[59],v[59],v[51],v[8],v[8],v[13],v[34],v[34],v[32],v[8],v[8],v[51],v[24],v[1],v[8],v[53],v[53],v[35],v[1],v[8],v[24],v[58],v[58],v[53],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[43],v[3],v[29],v[29],v[57],v[43],v[3],v[24],v[63],v[63],v[29],v[3],v[3],v[45],v[24] }},
                { 4, new Vector3[] {v[19],v[57],v[29],v[19],v[29],v[63],v[63],v[34],v[19] }},
                { 3, new Vector3[] {v[8],v[13],v[34],v[34],v[24],v[8],v[8],v[24],v[5] }},
                { 0, new Vector3[] {v[0],v[5],v[24],v[24],v[45],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[21],v[36],v[36],v[15],v[0],v[4],v[16],v[64],v[64],v[10],v[4],v[4],v[10],v[12] }},
                { 4, new Vector3[] {v[2],v[35],v[36],v[36],v[21],v[2],v[19],v[10],v[64],v[64],v[34],v[19],v[19],v[57],v[10] }},
                { 3, new Vector3[] {v[1],v[15],v[36],v[36],v[35],v[1],v[8],v[13],v[34],v[34],v[16],v[8] }},
                { 5, new Vector3[] {v[43],v[12],v[10],v[10],v[57],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[8],v[13],v[34],v[34],v[16],v[8] }},
                { 1, new Vector3[] {v[4],v[16],v[64],v[64],v[10],v[4],v[4],v[10],v[12] }},
                { 4, new Vector3[] {v[19],v[10],v[64],v[64],v[34],v[19],v[19],v[57],v[10] }},
                { 5, new Vector3[] {v[43],v[12],v[10],v[10],v[57],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[7],v[17],v[26],v[26],v[46],v[7],v[4],v[47],v[65],v[65],v[5],v[4] }},
                { 4, new Vector3[] {v[19],v[57],v[26],v[26],v[34],v[19],v[2],v[35],v[65],v[65],v[6],v[2] }},
                { 5, new Vector3[] {v[43],v[46],v[26],v[26],v[57],v[43],v[3],v[6],v[65],v[65],v[47],v[3] }},
                { 3, new Vector3[] {v[13],v[34],v[26],v[26],v[17],v[13],v[1],v[5],v[65],v[65],v[35],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[43],v[46],v[26],v[26],v[57],v[43],v[3],v[45],v[66],v[66],v[47],v[3] }},
                { 3, new Vector3[] {v[13],v[34],v[26],v[26],v[17],v[13] }},
                { 4, new Vector3[] {v[19],v[57],v[26],v[26],v[34],v[19] }},
                { 2, new Vector3[] {v[7],v[17],v[26],v[26],v[46],v[7],v[4],v[47],v[66],v[66],v[11],v[4] }},
                { 0, new Vector3[] {v[0],v[11],v[66],v[66],v[45],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[13],v[34],v[26],v[26],v[17],v[13],v[1],v[15],v[67],v[67],v[35],v[1] }},
                { 5, new Vector3[] {v[43],v[46],v[26],v[26],v[57],v[43] }},
                { 2, new Vector3[] {v[7],v[17],v[26],v[26],v[46],v[7] }},
                { 4, new Vector3[] {v[19],v[57],v[26],v[26],v[34],v[19],v[2],v[35],v[67],v[67],v[21],v[2] }},
                { 1, new Vector3[] {v[0],v[21],v[67],v[67],v[15],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[13],v[34],v[26],v[26],v[17],v[13] }},
                { 5, new Vector3[] {v[43],v[46],v[26],v[26],v[57],v[43] }},
                { 2, new Vector3[] {v[7],v[17],v[26],v[26],v[46],v[7] }},
                { 4, new Vector3[] {v[19],v[57],v[26],v[26],v[34],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[7],v[43],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[1],v[2] }},
                { 6, new Vector3[] {v[43],v[68],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[7],v[69],v[10],v[10],v[68],v[7],v[70],v[43],v[68],v[68],v[10],v[70] }},
                { 1, new Vector3[] {v[69],v[4],v[0],v[0],v[10],v[69],v[3],v[70],v[10],v[10],v[0],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[5],v[71],v[71],v[51],v[4],v[4],v[51],v[69],v[3],v[70],v[27],v[3],v[27],v[72],v[72],v[6],v[3] }},
                { 0, new Vector3[] {v[1],v[32],v[71],v[71],v[5],v[1],v[1],v[2],v[38],v[38],v[32],v[1],v[2],v[6],v[72],v[72],v[38],v[2] }},
                { 6, new Vector3[] {v[68],v[51],v[71],v[71],v[32],v[68],v[68],v[7],v[69],v[69],v[51],v[68],v[68],v[32],v[38],v[43],v[68],v[27],v[27],v[70],v[43],v[68],v[38],v[72],v[72],v[27],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[12],v[17],v[17],v[8],v[4] }},
                { 6, new Vector3[] {v[12],v[43],v[68],v[68],v[17],v[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[12],v[73],v[73],v[65],v[4],v[4],v[65],v[11],v[8],v[9],v[53],v[8],v[53],v[74],v[74],v[17],v[8] }},
                { 6, new Vector3[] {v[43],v[29],v[73],v[73],v[12],v[43],v[43],v[68],v[38],v[38],v[29],v[43],v[68],v[17],v[74],v[74],v[38],v[68] }},
                { 0, new Vector3[] {v[2],v[65],v[73],v[73],v[29],v[2],v[2],v[0],v[11],v[11],v[65],v[2],v[2],v[29],v[38],v[1],v[2],v[53],v[53],v[9],v[1],v[2],v[38],v[74],v[74],v[53],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[70],v[10],v[10],v[0],v[3],v[0],v[10],v[5] }},
                { 6, new Vector3[] {v[70],v[43],v[68],v[68],v[10],v[70],v[68],v[17],v[10] }},
                { 2, new Vector3[] {v[8],v[5],v[10],v[10],v[17],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[43],v[29],v[70],v[43],v[51],v[56],v[56],v[29],v[43],v[43],v[68],v[17],v[17],v[51],v[43] }},
                { 0, new Vector3[] {v[2],v[6],v[29],v[1],v[2],v[29],v[29],v[9],v[1] }},
                { 1, new Vector3[] {v[3],v[70],v[29],v[29],v[6],v[3] }},
                { 2, new Vector3[] {v[8],v[9],v[56],v[56],v[51],v[8],v[8],v[51],v[17] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[68],v[75],v[10],v[10],v[43],v[68],v[76],v[7],v[43],v[43],v[10],v[76] }},
                { 3, new Vector3[] {v[75],v[13],v[1],v[1],v[10],v[75],v[8],v[76],v[10],v[10],v[1],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[13],v[14],v[50],v[50],v[26],v[13],v[13],v[26],v[75],v[8],v[76],v[51],v[8],v[51],v[49],v[49],v[5],v[8] }},
                { 0, new Vector3[] {v[2],v[29],v[50],v[50],v[14],v[2],v[2],v[0],v[40],v[40],v[29],v[2],v[0],v[5],v[49],v[49],v[40],v[0] }},
                { 6, new Vector3[] {v[43],v[26],v[50],v[50],v[29],v[43],v[43],v[68],v[75],v[75],v[26],v[43],v[43],v[29],v[40],v[7],v[43],v[51],v[51],v[76],v[7],v[43],v[40],v[49],v[49],v[51],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[75],v[13],v[10],v[13],v[1],v[10],v[1],v[15],v[10],v[8],v[76],v[77],v[77],v[16],v[8] }},
                { 1, new Vector3[] {v[15],v[0],v[10],v[0],v[3],v[10],v[3],v[70],v[10],v[4],v[16],v[77],v[77],v[69],v[4] }},
                { 6, new Vector3[] {v[70],v[43],v[10],v[43],v[68],v[10],v[68],v[75],v[10],v[7],v[69],v[77],v[77],v[76],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[16],v[77],v[77],v[69],v[4],v[3],v[70],v[78],v[78],v[10],v[3],v[3],v[10],v[6] }},
                { 3, new Vector3[] {v[8],v[76],v[77],v[77],v[16],v[8],v[13],v[10],v[78],v[78],v[75],v[13],v[13],v[14],v[10] }},
                { 6, new Vector3[] {v[7],v[69],v[77],v[77],v[76],v[7],v[43],v[68],v[75],v[75],v[70],v[43] }},
                { 0, new Vector3[] {v[2],v[6],v[10],v[10],v[14],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[68],v[75],v[10],v[10],v[43],v[68],v[43],v[10],v[12] }},
                { 3, new Vector3[] {v[75],v[13],v[1],v[1],v[10],v[75],v[1],v[5],v[10] }},
                { 2, new Vector3[] {v[4],v[12],v[10],v[10],v[5],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[2],v[0],v[53],v[53],v[14],v[2],v[0],v[40],v[79],v[79],v[53],v[0],v[0],v[11],v[40] }},
                { 3, new Vector3[] {v[13],v[14],v[53],v[13],v[53],v[79],v[79],v[75],v[13] }},
                { 6, new Vector3[] {v[43],v[68],v[75],v[75],v[40],v[43],v[43],v[40],v[12] }},
                { 2, new Vector3[] {v[4],v[12],v[40],v[40],v[11],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[75],v[13],v[10],v[13],v[1],v[10],v[1],v[15],v[10] }},
                { 1, new Vector3[] {v[15],v[0],v[10],v[0],v[3],v[10],v[3],v[70],v[10] }},
                { 6, new Vector3[] {v[70],v[43],v[10],v[43],v[68],v[10],v[68],v[75],v[10] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[43],v[68],v[75],v[75],v[70],v[43] }},
                { 1, new Vector3[] {v[3],v[70],v[78],v[78],v[10],v[3],v[3],v[10],v[6] }},
                { 3, new Vector3[] {v[13],v[10],v[78],v[78],v[75],v[13],v[13],v[14],v[10] }},
                { 0, new Vector3[] {v[2],v[6],v[10],v[10],v[14],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[19],v[80],v[10],v[10],v[2],v[19],v[81],v[18],v[2],v[2],v[10],v[81] }},
                { 6, new Vector3[] {v[80],v[68],v[7],v[7],v[10],v[80],v[43],v[81],v[10],v[10],v[7],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[18],v[6],v[25],v[25],v[27],v[18],v[18],v[27],v[81],v[19],v[80],v[26],v[19],v[26],v[22],v[22],v[14],v[19] }},
                { 0, new Vector3[] {v[0],v[24],v[25],v[25],v[6],v[0],v[0],v[1],v[23],v[23],v[24],v[0],v[1],v[14],v[22],v[22],v[23],v[1] }},
                { 6, new Vector3[] {v[7],v[27],v[25],v[25],v[24],v[7],v[7],v[43],v[81],v[81],v[27],v[7],v[7],v[24],v[23],v[68],v[7],v[26],v[26],v[80],v[68],v[7],v[23],v[22],v[22],v[26],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[80],v[68],v[10],v[68],v[7],v[10],v[7],v[69],v[10],v[43],v[81],v[82],v[82],v[70],v[43] }},
                { 1, new Vector3[] {v[69],v[4],v[10],v[4],v[0],v[10],v[0],v[21],v[10],v[3],v[70],v[82],v[82],v[20],v[3] }},
                { 4, new Vector3[] {v[21],v[2],v[10],v[2],v[19],v[10],v[19],v[80],v[10],v[18],v[20],v[82],v[82],v[81],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[70],v[82],v[82],v[20],v[3],v[4],v[10],v[83],v[83],v[69],v[4],v[4],v[5],v[10] }},
                { 6, new Vector3[] {v[43],v[81],v[82],v[82],v[70],v[43],v[68],v[7],v[69],v[69],v[80],v[68] }},
                { 4, new Vector3[] {v[18],v[20],v[82],v[82],v[81],v[18],v[19],v[80],v[83],v[83],v[10],v[19],v[19],v[10],v[14] }},
                { 0, new Vector3[] {v[1],v[14],v[10],v[10],v[5],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[68],v[17],v[74],v[74],v[38],v[68],v[68],v[38],v[80],v[43],v[81],v[29],v[43],v[29],v[73],v[73],v[12],v[43] }},
                { 2, new Vector3[] {v[8],v[53],v[74],v[74],v[17],v[8],v[8],v[4],v[65],v[65],v[53],v[8],v[4],v[12],v[73],v[73],v[65],v[4] }},
                { 4, new Vector3[] {v[2],v[38],v[74],v[74],v[53],v[2],v[2],v[19],v[80],v[80],v[38],v[2],v[2],v[53],v[65],v[18],v[2],v[29],v[29],v[81],v[18],v[2],v[65],v[73],v[73],v[29],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[1],v[14],v[32],v[32],v[9],v[1],v[0],v[11],v[40],v[40],v[6],v[0] }},
                { 6, new Vector3[] {v[68],v[17],v[32],v[32],v[80],v[68],v[43],v[81],v[40],v[40],v[12],v[43] }},
                { 2, new Vector3[] {v[8],v[9],v[32],v[32],v[17],v[8],v[4],v[12],v[40],v[40],v[11],v[4] }},
                { 4, new Vector3[] {v[19],v[80],v[32],v[32],v[14],v[19],v[18],v[6],v[40],v[40],v[81],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[70],v[82],v[82],v[20],v[3],v[0],v[21],v[84],v[84],v[10],v[0],v[0],v[10],v[5] }},
                { 6, new Vector3[] {v[43],v[81],v[82],v[82],v[70],v[43],v[68],v[10],v[84],v[84],v[80],v[68],v[68],v[17],v[10] }},
                { 4, new Vector3[] {v[18],v[20],v[82],v[82],v[81],v[18],v[2],v[19],v[80],v[80],v[21],v[2] }},
                { 2, new Vector3[] {v[8],v[5],v[10],v[10],v[17],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[19],v[80],v[32],v[32],v[14],v[19],v[18],v[20],v[85],v[85],v[81],v[18] }},
                { 2, new Vector3[] {v[8],v[9],v[32],v[32],v[17],v[8] }},
                { 0, new Vector3[] {v[1],v[14],v[32],v[32],v[9],v[1] }},
                { 6, new Vector3[] {v[68],v[17],v[32],v[32],v[80],v[68],v[43],v[81],v[85],v[85],v[70],v[43] }},
                { 1, new Vector3[] {v[3],v[70],v[85],v[85],v[20],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[81],v[18],v[10],v[18],v[2],v[10],v[2],v[35],v[10],v[19],v[80],v[86],v[86],v[34],v[19] }},
                { 3, new Vector3[] {v[35],v[1],v[10],v[1],v[8],v[10],v[8],v[76],v[10],v[13],v[34],v[86],v[86],v[75],v[13] }},
                { 6, new Vector3[] {v[76],v[7],v[10],v[7],v[43],v[10],v[43],v[81],v[10],v[68],v[75],v[86],v[86],v[80],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[19],v[80],v[87],v[87],v[34],v[19],v[18],v[10],v[88],v[88],v[81],v[18],v[18],v[6],v[10] }},
                { 6, new Vector3[] {v[68],v[75],v[87],v[87],v[80],v[68],v[7],v[43],v[81],v[81],v[76],v[7] }},
                { 3, new Vector3[] {v[13],v[34],v[87],v[87],v[75],v[13],v[8],v[76],v[88],v[88],v[10],v[8],v[8],v[10],v[5] }},
                { 0, new Vector3[] {v[0],v[5],v[10],v[10],v[6],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[68],v[75],v[89],v[89],v[80],v[68],v[7],v[69],v[77],v[77],v[76],v[7],v[43],v[81],v[90],v[90],v[70],v[43] }},
                { 3, new Vector3[] {v[13],v[34],v[89],v[89],v[75],v[13],v[8],v[76],v[77],v[77],v[16],v[8],v[1],v[15],v[36],v[36],v[35],v[1] }},
                { 4, new Vector3[] {v[19],v[80],v[89],v[89],v[34],v[19],v[2],v[35],v[36],v[36],v[21],v[2],v[18],v[20],v[90],v[90],v[81],v[18] }},
                { 1, new Vector3[] {v[4],v[16],v[77],v[77],v[69],v[4],v[0],v[21],v[36],v[36],v[15],v[0],v[3],v[70],v[90],v[90],v[20],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[70],v[82],v[82],v[20],v[3],v[4],v[16],v[91],v[91],v[69],v[4] }},
                { 6, new Vector3[] {v[43],v[81],v[82],v[82],v[70],v[43],v[7],v[69],v[91],v[91],v[76],v[7],v[68],v[75],v[87],v[87],v[80],v[68] }},
                { 4, new Vector3[] {v[18],v[20],v[82],v[82],v[81],v[18],v[19],v[80],v[87],v[87],v[34],v[19] }},
                { 3, new Vector3[] {v[8],v[76],v[91],v[91],v[16],v[8],v[13],v[34],v[87],v[87],v[75],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[13],v[34],v[86],v[86],v[75],v[13],v[1],v[10],v[92],v[92],v[35],v[1],v[1],v[5],v[10] }},
                { 4, new Vector3[] {v[19],v[80],v[86],v[86],v[34],v[19],v[18],v[2],v[35],v[35],v[81],v[18] }},
                { 6, new Vector3[] {v[68],v[75],v[86],v[86],v[80],v[68],v[43],v[81],v[92],v[92],v[10],v[43],v[43],v[10],v[12] }},
                { 2, new Vector3[] {v[4],v[12],v[10],v[10],v[5],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[43],v[81],v[40],v[40],v[12],v[43],v[68],v[75],v[87],v[87],v[80],v[68] }},
                { 0, new Vector3[] {v[0],v[11],v[40],v[40],v[6],v[0] }},
                { 2, new Vector3[] {v[4],v[12],v[40],v[40],v[11],v[4] }},
                { 4, new Vector3[] {v[18],v[6],v[40],v[40],v[81],v[18],v[19],v[80],v[87],v[87],v[34],v[19] }},
                { 3, new Vector3[] {v[13],v[34],v[87],v[87],v[75],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[21],v[36],v[36],v[15],v[0],v[3],v[70],v[90],v[90],v[20],v[3] }},
                { 4, new Vector3[] {v[2],v[35],v[36],v[36],v[21],v[2],v[18],v[20],v[90],v[90],v[81],v[18],v[19],v[80],v[86],v[86],v[34],v[19] }},
                { 3, new Vector3[] {v[1],v[15],v[36],v[36],v[35],v[1],v[13],v[34],v[86],v[86],v[75],v[13] }},
                { 6, new Vector3[] {v[43],v[81],v[90],v[90],v[70],v[43],v[68],v[75],v[86],v[86],v[80],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[18],v[20],v[90],v[90],v[81],v[18],v[19],v[80],v[87],v[87],v[34],v[19] }},
                { 1, new Vector3[] {v[3],v[70],v[90],v[90],v[20],v[3] }},
                { 6, new Vector3[] {v[43],v[81],v[90],v[90],v[70],v[43],v[68],v[75],v[87],v[87],v[80],v[68] }},
                { 3, new Vector3[] {v[13],v[34],v[87],v[87],v[75],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[7],v[12],v[57],v[57],v[68],v[7] }},
                { 5, new Vector3[] {v[12],v[3],v[18],v[18],v[57],v[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[18],v[57],v[93],v[93],v[30],v[18],v[18],v[30],v[44],v[3],v[45],v[65],v[3],v[65],v[94],v[94],v[12],v[3] }},
                { 6, new Vector3[] {v[68],v[32],v[93],v[93],v[57],v[68],v[68],v[7],v[23],v[23],v[32],v[68],v[7],v[12],v[94],v[94],v[23],v[7] }},
                { 0, new Vector3[] {v[1],v[30],v[93],v[93],v[32],v[1],v[1],v[2],v[44],v[44],v[30],v[1],v[1],v[32],v[23],v[0],v[1],v[65],v[65],v[45],v[0],v[1],v[23],v[94],v[94],v[65],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[7],v[69],v[10],v[10],v[68],v[7],v[68],v[10],v[57] }},
                { 1, new Vector3[] {v[69],v[4],v[0],v[0],v[10],v[69],v[0],v[6],v[10] }},
                { 5, new Vector3[] {v[18],v[57],v[10],v[10],v[6],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[1],v[2],v[65],v[65],v[5],v[1],v[2],v[38],v[62],v[62],v[65],v[2],v[2],v[44],v[38] }},
                { 1, new Vector3[] {v[4],v[5],v[65],v[4],v[65],v[62],v[62],v[69],v[4] }},
                { 6, new Vector3[] {v[68],v[7],v[69],v[69],v[38],v[68],v[68],v[38],v[57] }},
                { 5, new Vector3[] {v[18],v[57],v[38],v[38],v[44],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[47],v[10],v[10],v[8],v[4],v[8],v[10],v[17] }},
                { 5, new Vector3[] {v[47],v[3],v[18],v[18],v[10],v[47],v[18],v[57],v[10] }},
                { 6, new Vector3[] {v[68],v[17],v[10],v[10],v[57],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[47],v[66],v[66],v[11],v[4],v[8],v[9],v[95],v[95],v[10],v[8],v[8],v[10],v[17] }},
                { 5, new Vector3[] {v[3],v[45],v[66],v[66],v[47],v[3],v[18],v[10],v[95],v[95],v[44],v[18],v[18],v[57],v[10] }},
                { 0, new Vector3[] {v[0],v[11],v[66],v[66],v[45],v[0],v[1],v[2],v[44],v[44],v[9],v[1] }},
                { 6, new Vector3[] {v[68],v[17],v[10],v[10],v[57],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[6],v[10],v[10],v[5],v[0] }},
                { 5, new Vector3[] {v[18],v[57],v[10],v[10],v[6],v[18] }},
                { 2, new Vector3[] {v[8],v[5],v[10],v[10],v[17],v[8] }},
                { 6, new Vector3[] {v[68],v[17],v[10],v[10],v[57],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[1],v[2],v[44],v[44],v[9],v[1] }},
                { 2, new Vector3[] {v[8],v[9],v[95],v[95],v[10],v[8],v[8],v[10],v[17] }},
                { 5, new Vector3[] {v[18],v[10],v[95],v[95],v[44],v[18],v[18],v[57],v[10] }},
                { 6, new Vector3[] {v[68],v[17],v[10],v[10],v[57],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[7],v[12],v[94],v[94],v[23],v[7],v[7],v[23],v[76],v[68],v[75],v[32],v[68],v[32],v[93],v[93],v[57],v[68] }},
                { 5, new Vector3[] {v[3],v[65],v[94],v[94],v[12],v[3],v[3],v[18],v[30],v[30],v[65],v[3],v[18],v[57],v[93],v[93],v[30],v[18] }},
                { 3, new Vector3[] {v[1],v[23],v[94],v[94],v[65],v[1],v[1],v[8],v[76],v[76],v[23],v[1],v[1],v[65],v[30],v[13],v[1],v[32],v[32],v[75],v[13],v[1],v[30],v[93],v[93],v[32],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[18],v[57],v[38],v[38],v[44],v[18],v[3],v[45],v[24],v[24],v[12],v[3] }},
                { 3, new Vector3[] {v[13],v[14],v[38],v[38],v[75],v[13],v[8],v[76],v[24],v[24],v[5],v[8] }},
                { 0, new Vector3[] {v[2],v[44],v[38],v[38],v[14],v[2],v[0],v[5],v[24],v[24],v[45],v[0] }},
                { 6, new Vector3[] {v[68],v[75],v[38],v[38],v[57],v[68],v[7],v[12],v[24],v[24],v[76],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[16],v[77],v[77],v[69],v[4],v[0],v[10],v[96],v[96],v[15],v[0],v[0],v[6],v[10] }},
                { 3, new Vector3[] {v[8],v[76],v[77],v[77],v[16],v[8],v[13],v[1],v[15],v[15],v[75],v[13] }},
                { 6, new Vector3[] {v[7],v[69],v[77],v[77],v[76],v[7],v[68],v[75],v[96],v[96],v[10],v[68],v[68],v[10],v[57] }},
                { 5, new Vector3[] {v[18],v[57],v[10],v[10],v[6],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[68],v[75],v[38],v[38],v[57],v[68],v[7],v[69],v[97],v[97],v[76],v[7] }},
                { 0, new Vector3[] {v[2],v[44],v[38],v[38],v[14],v[2] }},
                { 5, new Vector3[] {v[18],v[57],v[38],v[38],v[44],v[18] }},
                { 3, new Vector3[] {v[13],v[14],v[38],v[38],v[75],v[13],v[8],v[76],v[97],v[97],v[16],v[8] }},
                { 1, new Vector3[] {v[4],v[16],v[97],v[97],v[69],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[18],v[57],v[57],v[27],v[3],v[3],v[27],v[63],v[63],v[65],v[3],v[3],v[65],v[47] }},
                { 6, new Vector3[] {v[68],v[27],v[57],v[68],v[75],v[63],v[63],v[27],v[68] }},
                { 3, new Vector3[] {v[13],v[1],v[65],v[65],v[75],v[13],v[1],v[5],v[65] }},
                { 2, new Vector3[] {v[4],v[47],v[65],v[65],v[5],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[2],v[44],v[38],v[38],v[14],v[2],v[0],v[11],v[60],v[60],v[45],v[0] }},
                { 6, new Vector3[] {v[68],v[75],v[38],v[38],v[57],v[68] }},
                { 3, new Vector3[] {v[13],v[14],v[38],v[38],v[75],v[13] }},
                { 5, new Vector3[] {v[18],v[57],v[38],v[38],v[44],v[18],v[3],v[45],v[60],v[60],v[47],v[3] }},
                { 2, new Vector3[] {v[4],v[47],v[60],v[60],v[11],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[13],v[1],v[15],v[15],v[75],v[13] }},
                { 6, new Vector3[] {v[68],v[75],v[96],v[96],v[10],v[68],v[68],v[10],v[57] }},
                { 1, new Vector3[] {v[0],v[10],v[96],v[96],v[15],v[0],v[0],v[6],v[10] }},
                { 5, new Vector3[] {v[18],v[57],v[10],v[10],v[6],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[68],v[75],v[38],v[38],v[57],v[68] }},
                { 0, new Vector3[] {v[2],v[44],v[38],v[38],v[14],v[2] }},
                { 5, new Vector3[] {v[18],v[57],v[38],v[38],v[44],v[18] }},
                { 3, new Vector3[] {v[13],v[14],v[38],v[38],v[75],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[19],v[80],v[10],v[10],v[2],v[19],v[2],v[10],v[6] }},
                { 6, new Vector3[] {v[80],v[68],v[7],v[7],v[10],v[80],v[7],v[12],v[10] }},
                { 5, new Vector3[] {v[3],v[6],v[10],v[10],v[12],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[1],v[14],v[14],v[30],v[0],v[0],v[30],v[79],v[79],v[24],v[0],v[0],v[24],v[45] }},
                { 4, new Vector3[] {v[19],v[30],v[14],v[19],v[80],v[79],v[79],v[30],v[19] }},
                { 6, new Vector3[] {v[68],v[7],v[24],v[24],v[80],v[68],v[7],v[12],v[24] }},
                { 5, new Vector3[] {v[3],v[45],v[24],v[24],v[12],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[80],v[68],v[10],v[68],v[7],v[10],v[7],v[69],v[10] }},
                { 1, new Vector3[] {v[69],v[4],v[10],v[4],v[0],v[10],v[0],v[21],v[10] }},
                { 4, new Vector3[] {v[21],v[2],v[10],v[2],v[19],v[10],v[19],v[80],v[10] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[68],v[7],v[69],v[69],v[80],v[68] }},
                { 4, new Vector3[] {v[19],v[80],v[83],v[83],v[10],v[19],v[19],v[10],v[14] }},
                { 1, new Vector3[] {v[4],v[10],v[83],v[83],v[69],v[4],v[4],v[5],v[10] }},
                { 0, new Vector3[] {v[1],v[14],v[10],v[10],v[5],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[8],v[4],v[51],v[51],v[17],v[8],v[4],v[65],v[41],v[41],v[51],v[4],v[4],v[47],v[65] }},
                { 6, new Vector3[] {v[68],v[17],v[51],v[68],v[51],v[41],v[41],v[80],v[68] }},
                { 4, new Vector3[] {v[2],v[19],v[80],v[80],v[65],v[2],v[2],v[65],v[6] }},
                { 5, new Vector3[] {v[3],v[6],v[65],v[65],v[47],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[8],v[9],v[32],v[32],v[17],v[8],v[4],v[47],v[48],v[48],v[11],v[4] }},
                { 4, new Vector3[] {v[19],v[80],v[32],v[32],v[14],v[19] }},
                { 6, new Vector3[] {v[68],v[17],v[32],v[32],v[80],v[68] }},
                { 0, new Vector3[] {v[1],v[14],v[32],v[32],v[9],v[1],v[0],v[11],v[48],v[48],v[45],v[0] }},
                { 5, new Vector3[] {v[3],v[45],v[48],v[48],v[47],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[2],v[19],v[80],v[80],v[21],v[2] }},
                { 1, new Vector3[] {v[0],v[21],v[84],v[84],v[10],v[0],v[0],v[10],v[5] }},
                { 6, new Vector3[] {v[68],v[10],v[84],v[84],v[80],v[68],v[68],v[17],v[10] }},
                { 2, new Vector3[] {v[8],v[5],v[10],v[10],v[17],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[19],v[80],v[32],v[32],v[14],v[19] }},
                { 2, new Vector3[] {v[8],v[9],v[32],v[32],v[17],v[8] }},
                { 0, new Vector3[] {v[1],v[14],v[32],v[32],v[9],v[1] }},
                { 6, new Vector3[] {v[68],v[17],v[32],v[32],v[80],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[68],v[75],v[89],v[89],v[80],v[68],v[7],v[10],v[98],v[98],v[76],v[7],v[7],v[12],v[10] }},
                { 3, new Vector3[] {v[13],v[34],v[89],v[89],v[75],v[13],v[1],v[8],v[76],v[76],v[35],v[1] }},
                { 4, new Vector3[] {v[19],v[80],v[89],v[89],v[34],v[19],v[2],v[35],v[98],v[98],v[10],v[2],v[2],v[10],v[6] }},
                { 5, new Vector3[] {v[3],v[6],v[10],v[10],v[12],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[8],v[76],v[24],v[24],v[5],v[8],v[13],v[34],v[89],v[89],v[75],v[13] }},
                { 5, new Vector3[] {v[3],v[45],v[24],v[24],v[12],v[3] }},
                { 0, new Vector3[] {v[0],v[5],v[24],v[24],v[45],v[0] }},
                { 6, new Vector3[] {v[7],v[12],v[24],v[24],v[76],v[7],v[68],v[75],v[89],v[89],v[80],v[68] }},
                { 4, new Vector3[] {v[19],v[80],v[89],v[89],v[34],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[16],v[77],v[77],v[69],v[4],v[0],v[21],v[99],v[99],v[15],v[0] }},
                { 3, new Vector3[] {v[8],v[76],v[77],v[77],v[16],v[8],v[1],v[15],v[99],v[99],v[35],v[1],v[13],v[34],v[89],v[89],v[75],v[13] }},
                { 6, new Vector3[] {v[7],v[69],v[77],v[77],v[76],v[7],v[68],v[75],v[89],v[89],v[80],v[68] }},
                { 4, new Vector3[] {v[2],v[35],v[99],v[99],v[21],v[2],v[19],v[80],v[89],v[89],v[34],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[7],v[69],v[91],v[91],v[76],v[7],v[68],v[75],v[89],v[89],v[80],v[68] }},
                { 1, new Vector3[] {v[4],v[16],v[91],v[91],v[69],v[4] }},
                { 3, new Vector3[] {v[8],v[76],v[91],v[91],v[16],v[8],v[13],v[34],v[89],v[89],v[75],v[13] }},
                { 4, new Vector3[] {v[19],v[80],v[89],v[89],v[34],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[2],v[35],v[65],v[65],v[6],v[2],v[19],v[80],v[86],v[86],v[34],v[19] }},
                { 2, new Vector3[] {v[4],v[47],v[65],v[65],v[5],v[4] }},
                { 5, new Vector3[] {v[3],v[6],v[65],v[65],v[47],v[3] }},
                { 3, new Vector3[] {v[1],v[5],v[65],v[65],v[35],v[1],v[13],v[34],v[86],v[86],v[75],v[13] }},
                { 6, new Vector3[] {v[68],v[75],v[86],v[86],v[80],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[11],v[48],v[48],v[45],v[0] }},
                { 2, new Vector3[] {v[4],v[47],v[48],v[48],v[11],v[4] }},
                { 5, new Vector3[] {v[3],v[45],v[48],v[48],v[47],v[3] }},
                { 3, new Vector3[] {v[13],v[34],v[86],v[86],v[75],v[13] }},
                { 4, new Vector3[] {v[19],v[80],v[86],v[86],v[34],v[19] }},
                { 6, new Vector3[] {v[68],v[75],v[86],v[86],v[80],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[1],v[15],v[99],v[99],v[35],v[1],v[13],v[34],v[86],v[86],v[75],v[13] }},
                { 1, new Vector3[] {v[0],v[21],v[99],v[99],v[15],v[0] }},
                { 4, new Vector3[] {v[2],v[35],v[99],v[99],v[21],v[2],v[19],v[80],v[86],v[86],v[34],v[19] }},
                { 6, new Vector3[] {v[68],v[75],v[86],v[86],v[80],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[19],v[80],v[87],v[87],v[34],v[19] }},
                { 6, new Vector3[] {v[68],v[75],v[87],v[87],v[80],v[68] }},
                { 3, new Vector3[] {v[13],v[34],v[87],v[87],v[75],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[19],v[13],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[19],v[100],v[10],v[10],v[68],v[19],v[101],v[13],v[68],v[68],v[10],v[101] }},
                { 0, new Vector3[] {v[100],v[2],v[0],v[0],v[10],v[100],v[1],v[101],v[10],v[10],v[0],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[3],v[4] }},
                { 7, new Vector3[] {v[13],v[68],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[2],v[6],v[72],v[72],v[38],v[2],v[2],v[38],v[100],v[1],v[101],v[32],v[1],v[32],v[71],v[71],v[5],v[1] }},
                { 1, new Vector3[] {v[3],v[27],v[72],v[72],v[6],v[3],v[3],v[4],v[51],v[51],v[27],v[3],v[4],v[5],v[71],v[71],v[51],v[4] }},
                { 7, new Vector3[] {v[68],v[38],v[72],v[72],v[27],v[68],v[68],v[19],v[100],v[100],v[38],v[68],v[68],v[27],v[51],v[13],v[68],v[32],v[32],v[101],v[13],v[68],v[51],v[71],v[71],v[32],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[13],v[102],v[10],v[10],v[19],v[13],v[103],v[68],v[19],v[19],v[10],v[103] }},
                { 2, new Vector3[] {v[102],v[8],v[4],v[4],v[10],v[102],v[7],v[103],v[10],v[10],v[4],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[100],v[2],v[10],v[2],v[0],v[10],v[0],v[11],v[10],v[1],v[101],v[104],v[104],v[9],v[1] }},
                { 2, new Vector3[] {v[11],v[4],v[10],v[4],v[7],v[10],v[7],v[103],v[10],v[8],v[9],v[104],v[104],v[102],v[8] }},
                { 7, new Vector3[] {v[103],v[68],v[10],v[68],v[19],v[10],v[19],v[100],v[10],v[13],v[102],v[104],v[104],v[101],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[8],v[5],v[31],v[31],v[32],v[8],v[8],v[32],v[102],v[7],v[103],v[26],v[7],v[26],v[28],v[28],v[12],v[7] }},
                { 1, new Vector3[] {v[0],v[30],v[31],v[31],v[5],v[0],v[0],v[3],v[29],v[29],v[30],v[0],v[3],v[12],v[28],v[28],v[29],v[3] }},
                { 7, new Vector3[] {v[19],v[32],v[31],v[31],v[30],v[19],v[19],v[13],v[102],v[102],v[32],v[19],v[19],v[30],v[29],v[68],v[19],v[26],v[26],v[103],v[68],v[19],v[29],v[28],v[28],v[26],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[8],v[9],v[104],v[104],v[102],v[8],v[7],v[103],v[105],v[105],v[10],v[7],v[7],v[10],v[12] }},
                { 0, new Vector3[] {v[1],v[101],v[104],v[104],v[9],v[1],v[2],v[10],v[105],v[105],v[100],v[2],v[2],v[6],v[10] }},
                { 7, new Vector3[] {v[13],v[102],v[104],v[104],v[101],v[13],v[68],v[19],v[100],v[100],v[103],v[68] }},
                { 1, new Vector3[] {v[3],v[12],v[10],v[10],v[6],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[19],v[14],v[17],v[17],v[68],v[19] }},
                { 3, new Vector3[] {v[14],v[1],v[8],v[8],v[17],v[14] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[19],v[100],v[10],v[10],v[68],v[19],v[68],v[10],v[17] }},
                { 0, new Vector3[] {v[100],v[2],v[0],v[0],v[10],v[100],v[0],v[5],v[10] }},
                { 3, new Vector3[] {v[8],v[17],v[10],v[10],v[5],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[8],v[17],v[106],v[106],v[24],v[8],v[8],v[24],v[16],v[1],v[15],v[65],v[1],v[65],v[107],v[107],v[14],v[1] }},
                { 7, new Vector3[] {v[68],v[27],v[106],v[106],v[17],v[68],v[68],v[19],v[29],v[29],v[27],v[68],v[19],v[14],v[107],v[107],v[29],v[19] }},
                { 1, new Vector3[] {v[3],v[24],v[106],v[106],v[27],v[3],v[3],v[4],v[16],v[16],v[24],v[3],v[3],v[27],v[29],v[0],v[3],v[65],v[65],v[15],v[0],v[3],v[29],v[107],v[107],v[65],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[16],v[51],v[4],v[51],v[41],v[41],v[65],v[4],v[3],v[4],v[65],v[65],v[6],v[3] }},
                { 3, new Vector3[] {v[8],v[17],v[51],v[51],v[16],v[8] }},
                { 7, new Vector3[] {v[68],v[51],v[17],v[68],v[19],v[100],v[100],v[51],v[68] }},
                { 0, new Vector3[] {v[2],v[65],v[41],v[41],v[100],v[2],v[2],v[6],v[65] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[7],v[103],v[10],v[10],v[4],v[7],v[4],v[10],v[5] }},
                { 7, new Vector3[] {v[103],v[68],v[19],v[19],v[10],v[103],v[19],v[14],v[10] }},
                { 3, new Vector3[] {v[1],v[5],v[10],v[10],v[14],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[103],v[68],v[10],v[68],v[19],v[10],v[19],v[100],v[10] }},
                { 0, new Vector3[] {v[100],v[2],v[10],v[2],v[0],v[10],v[0],v[11],v[10] }},
                { 2, new Vector3[] {v[11],v[4],v[10],v[4],v[7],v[10],v[7],v[103],v[10] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[30],v[15],v[0],v[24],v[79],v[79],v[30],v[0],v[0],v[3],v[12],v[12],v[24],v[0] }},
                { 7, new Vector3[] {v[19],v[14],v[30],v[68],v[19],v[30],v[30],v[103],v[68] }},
                { 3, new Vector3[] {v[1],v[15],v[30],v[30],v[14],v[1] }},
                { 2, new Vector3[] {v[7],v[103],v[79],v[79],v[24],v[7],v[7],v[24],v[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[68],v[19],v[100],v[100],v[103],v[68] }},
                { 2, new Vector3[] {v[7],v[103],v[105],v[105],v[10],v[7],v[7],v[10],v[12] }},
                { 0, new Vector3[] {v[2],v[10],v[105],v[105],v[100],v[2],v[2],v[6],v[10] }},
                { 1, new Vector3[] {v[3],v[12],v[10],v[10],v[6],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[68],v[57],v[14],v[14],v[13],v[68] }},
                { 4, new Vector3[] {v[57],v[18],v[2],v[2],v[14],v[57] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[1],v[101],v[10],v[10],v[0],v[1],v[0],v[10],v[6] }},
                { 7, new Vector3[] {v[101],v[13],v[68],v[68],v[10],v[101],v[68],v[57],v[10] }},
                { 4, new Vector3[] {v[18],v[6],v[10],v[10],v[57],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[2],v[14],v[108],v[108],v[65],v[2],v[2],v[65],v[21],v[18],v[20],v[40],v[18],v[40],v[109],v[109],v[57],v[18] }},
                { 7, new Vector3[] {v[13],v[23],v[108],v[108],v[14],v[13],v[13],v[68],v[51],v[51],v[23],v[13],v[68],v[57],v[109],v[109],v[51],v[68] }},
                { 1, new Vector3[] {v[4],v[65],v[108],v[108],v[23],v[4],v[4],v[0],v[21],v[21],v[65],v[4],v[4],v[23],v[51],v[3],v[4],v[40],v[40],v[20],v[3],v[4],v[51],v[109],v[109],v[40],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[27],v[20],v[3],v[65],v[63],v[63],v[27],v[3],v[3],v[4],v[5],v[5],v[65],v[3] }},
                { 7, new Vector3[] {v[68],v[57],v[27],v[13],v[68],v[27],v[27],v[101],v[13] }},
                { 4, new Vector3[] {v[18],v[20],v[27],v[27],v[57],v[18] }},
                { 0, new Vector3[] {v[1],v[101],v[63],v[63],v[65],v[1],v[1],v[65],v[5] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[68],v[57],v[109],v[109],v[51],v[68],v[68],v[51],v[103],v[13],v[102],v[23],v[13],v[23],v[108],v[108],v[14],v[13] }},
                { 4, new Vector3[] {v[18],v[40],v[109],v[109],v[57],v[18],v[18],v[2],v[65],v[65],v[40],v[18],v[2],v[14],v[108],v[108],v[65],v[2] }},
                { 2, new Vector3[] {v[4],v[51],v[109],v[109],v[40],v[4],v[4],v[7],v[103],v[103],v[51],v[4],v[4],v[40],v[65],v[8],v[4],v[23],v[23],v[102],v[8],v[4],v[65],v[108],v[108],v[23],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[1],v[101],v[110],v[110],v[9],v[1],v[0],v[11],v[111],v[111],v[10],v[0],v[0],v[10],v[6] }},
                { 7, new Vector3[] {v[13],v[102],v[110],v[110],v[101],v[13],v[68],v[10],v[111],v[111],v[103],v[68],v[68],v[57],v[10] }},
                { 2, new Vector3[] {v[8],v[9],v[110],v[110],v[102],v[8],v[4],v[7],v[103],v[103],v[11],v[4] }},
                { 4, new Vector3[] {v[18],v[6],v[10],v[10],v[57],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[21],v[53],v[53],v[5],v[0],v[3],v[12],v[27],v[27],v[20],v[3] }},
                { 4, new Vector3[] {v[2],v[14],v[53],v[53],v[21],v[2],v[18],v[20],v[27],v[27],v[57],v[18] }},
                { 2, new Vector3[] {v[8],v[5],v[53],v[53],v[102],v[8],v[7],v[103],v[27],v[27],v[12],v[7] }},
                { 7, new Vector3[] {v[13],v[102],v[53],v[53],v[14],v[13],v[68],v[57],v[27],v[27],v[103],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[7],v[103],v[27],v[27],v[12],v[7],v[8],v[9],v[112],v[112],v[102],v[8] }},
                { 4, new Vector3[] {v[18],v[20],v[27],v[27],v[57],v[18] }},
                { 1, new Vector3[] {v[3],v[12],v[27],v[27],v[20],v[3] }},
                { 7, new Vector3[] {v[68],v[57],v[27],v[27],v[103],v[68],v[13],v[102],v[112],v[112],v[101],v[13] }},
                { 0, new Vector3[] {v[1],v[101],v[112],v[112],v[9],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[2],v[35],v[10],v[10],v[18],v[2],v[18],v[10],v[57] }},
                { 3, new Vector3[] {v[35],v[1],v[8],v[8],v[10],v[35],v[8],v[17],v[10] }},
                { 7, new Vector3[] {v[68],v[57],v[10],v[10],v[17],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[5],v[10],v[10],v[6],v[0] }},
                { 3, new Vector3[] {v[8],v[17],v[10],v[10],v[5],v[8] }},
                { 4, new Vector3[] {v[18],v[6],v[10],v[10],v[57],v[18] }},
                { 7, new Vector3[] {v[68],v[57],v[10],v[10],v[17],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[1],v[15],v[99],v[99],v[35],v[1],v[8],v[10],v[113],v[113],v[16],v[8],v[8],v[17],v[10] }},
                { 1, new Vector3[] {v[0],v[21],v[99],v[99],v[15],v[0],v[3],v[4],v[16],v[16],v[20],v[3] }},
                { 4, new Vector3[] {v[2],v[35],v[99],v[99],v[21],v[2],v[18],v[20],v[113],v[113],v[10],v[18],v[18],v[10],v[57] }},
                { 7, new Vector3[] {v[68],v[57],v[10],v[10],v[17],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[4],v[16],v[16],v[20],v[3] }},
                { 4, new Vector3[] {v[18],v[20],v[113],v[113],v[10],v[18],v[18],v[10],v[57] }},
                { 3, new Vector3[] {v[8],v[10],v[113],v[113],v[16],v[8],v[8],v[17],v[10] }},
                { 7, new Vector3[] {v[68],v[57],v[10],v[10],v[17],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[2],v[35],v[65],v[2],v[65],v[62],v[62],v[38],v[2],v[18],v[2],v[38],v[38],v[57],v[18] }},
                { 3, new Vector3[] {v[1],v[5],v[65],v[65],v[35],v[1] }},
                { 2, new Vector3[] {v[4],v[65],v[5],v[4],v[7],v[103],v[103],v[65],v[4] }},
                { 7, new Vector3[] {v[68],v[38],v[62],v[62],v[103],v[68],v[68],v[57],v[38] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[7],v[103],v[103],v[11],v[4] }},
                { 0, new Vector3[] {v[0],v[11],v[111],v[111],v[10],v[0],v[0],v[10],v[6] }},
                { 7, new Vector3[] {v[68],v[10],v[111],v[111],v[103],v[68],v[68],v[57],v[10] }},
                { 4, new Vector3[] {v[18],v[6],v[10],v[10],v[57],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[18],v[20],v[27],v[27],v[57],v[18],v[2],v[35],v[36],v[36],v[21],v[2] }},
                { 2, new Vector3[] {v[7],v[103],v[27],v[27],v[12],v[7] }},
                { 7, new Vector3[] {v[68],v[57],v[27],v[27],v[103],v[68] }},
                { 1, new Vector3[] {v[3],v[12],v[27],v[27],v[20],v[3],v[0],v[21],v[36],v[36],v[15],v[0] }},
                { 3, new Vector3[] {v[1],v[15],v[36],v[36],v[35],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[7],v[103],v[27],v[27],v[12],v[7] }},
                { 4, new Vector3[] {v[18],v[20],v[27],v[27],v[57],v[18] }},
                { 1, new Vector3[] {v[3],v[12],v[27],v[27],v[20],v[3] }},
                { 7, new Vector3[] {v[68],v[57],v[27],v[27],v[103],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[68],v[114],v[10],v[10],v[13],v[68],v[115],v[19],v[13],v[13],v[10],v[115] }},
                { 5, new Vector3[] {v[114],v[43],v[3],v[3],v[10],v[114],v[18],v[115],v[10],v[10],v[3],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[114],v[43],v[10],v[43],v[3],v[10],v[3],v[45],v[10],v[18],v[115],v[116],v[116],v[44],v[18] }},
                { 0, new Vector3[] {v[45],v[0],v[10],v[0],v[1],v[10],v[1],v[101],v[10],v[2],v[44],v[116],v[116],v[100],v[2] }},
                { 7, new Vector3[] {v[101],v[13],v[10],v[13],v[68],v[10],v[68],v[114],v[10],v[19],v[100],v[116],v[116],v[115],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[43],v[12],v[54],v[54],v[26],v[43],v[43],v[26],v[114],v[18],v[115],v[38],v[18],v[38],v[52],v[52],v[6],v[18] }},
                { 1, new Vector3[] {v[4],v[23],v[54],v[54],v[12],v[4],v[4],v[0],v[53],v[53],v[23],v[4],v[0],v[6],v[52],v[52],v[53],v[0] }},
                { 7, new Vector3[] {v[13],v[26],v[54],v[54],v[23],v[13],v[13],v[68],v[114],v[114],v[26],v[13],v[13],v[23],v[53],v[19],v[13],v[38],v[38],v[115],v[19],v[13],v[53],v[52],v[52],v[38],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[2],v[44],v[116],v[116],v[100],v[2],v[1],v[101],v[117],v[117],v[10],v[1],v[1],v[10],v[5] }},
                { 5, new Vector3[] {v[18],v[115],v[116],v[116],v[44],v[18],v[43],v[10],v[117],v[117],v[114],v[43],v[43],v[12],v[10] }},
                { 7, new Vector3[] {v[19],v[100],v[116],v[116],v[115],v[19],v[13],v[68],v[114],v[114],v[101],v[13] }},
                { 1, new Vector3[] {v[4],v[5],v[10],v[10],v[12],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[102],v[8],v[10],v[8],v[4],v[10],v[4],v[47],v[10],v[7],v[103],v[118],v[118],v[46],v[7] }},
                { 5, new Vector3[] {v[47],v[3],v[10],v[3],v[18],v[10],v[18],v[115],v[10],v[43],v[46],v[118],v[118],v[114],v[43] }},
                { 7, new Vector3[] {v[115],v[19],v[10],v[19],v[13],v[10],v[13],v[102],v[10],v[68],v[114],v[118],v[118],v[103],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[11],v[48],v[48],v[45],v[0],v[2],v[44],v[119],v[119],v[100],v[2],v[1],v[101],v[104],v[104],v[9],v[1] }},
                { 2, new Vector3[] {v[4],v[47],v[48],v[48],v[11],v[4],v[8],v[9],v[104],v[104],v[102],v[8],v[7],v[103],v[118],v[118],v[46],v[7] }},
                { 5, new Vector3[] {v[3],v[45],v[48],v[48],v[47],v[3],v[18],v[115],v[119],v[119],v[44],v[18],v[43],v[46],v[118],v[118],v[114],v[43] }},
                { 7, new Vector3[] {v[19],v[100],v[119],v[119],v[115],v[19],v[13],v[102],v[104],v[104],v[101],v[13],v[68],v[114],v[118],v[118],v[103],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[43],v[46],v[118],v[118],v[114],v[43],v[18],v[115],v[120],v[120],v[10],v[18],v[18],v[10],v[6] }},
                { 2, new Vector3[] {v[7],v[103],v[118],v[118],v[46],v[7],v[8],v[10],v[120],v[120],v[102],v[8],v[8],v[5],v[10] }},
                { 7, new Vector3[] {v[68],v[114],v[118],v[118],v[103],v[68],v[19],v[13],v[102],v[102],v[115],v[19] }},
                { 1, new Vector3[] {v[0],v[6],v[10],v[10],v[5],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[1],v[101],v[110],v[110],v[9],v[1],v[2],v[44],v[121],v[121],v[100],v[2] }},
                { 7, new Vector3[] {v[13],v[102],v[110],v[110],v[101],v[13],v[19],v[100],v[121],v[121],v[115],v[19],v[68],v[114],v[122],v[122],v[103],v[68] }},
                { 2, new Vector3[] {v[8],v[9],v[110],v[110],v[102],v[8],v[7],v[103],v[122],v[122],v[46],v[7] }},
                { 5, new Vector3[] {v[18],v[115],v[121],v[121],v[44],v[18],v[43],v[46],v[122],v[122],v[114],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[19],v[14],v[107],v[107],v[29],v[19],v[19],v[29],v[115],v[68],v[114],v[27],v[68],v[27],v[106],v[106],v[17],v[68] }},
                { 3, new Vector3[] {v[1],v[65],v[107],v[107],v[14],v[1],v[1],v[8],v[24],v[24],v[65],v[1],v[8],v[17],v[106],v[106],v[24],v[8] }},
                { 5, new Vector3[] {v[3],v[29],v[107],v[107],v[65],v[3],v[3],v[18],v[115],v[115],v[29],v[3],v[3],v[65],v[24],v[43],v[3],v[27],v[27],v[114],v[43],v[3],v[24],v[106],v[106],v[27],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[2],v[44],v[116],v[116],v[100],v[2],v[0],v[10],v[123],v[123],v[45],v[0],v[0],v[5],v[10] }},
                { 5, new Vector3[] {v[18],v[115],v[116],v[116],v[44],v[18],v[43],v[3],v[45],v[45],v[114],v[43] }},
                { 7, new Vector3[] {v[19],v[100],v[116],v[116],v[115],v[19],v[68],v[114],v[123],v[123],v[10],v[68],v[68],v[10],v[17] }},
                { 3, new Vector3[] {v[8],v[17],v[10],v[10],v[5],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[16],v[51],v[51],v[12],v[4],v[0],v[6],v[30],v[30],v[15],v[0] }},
                { 3, new Vector3[] {v[8],v[17],v[51],v[51],v[16],v[8],v[1],v[15],v[30],v[30],v[14],v[1] }},
                { 5, new Vector3[] {v[43],v[12],v[51],v[51],v[114],v[43],v[18],v[115],v[30],v[30],v[6],v[18] }},
                { 7, new Vector3[] {v[68],v[114],v[51],v[51],v[17],v[68],v[19],v[14],v[30],v[30],v[115],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[68],v[114],v[51],v[51],v[17],v[68],v[19],v[100],v[119],v[119],v[115],v[19] }},
                { 1, new Vector3[] {v[4],v[16],v[51],v[51],v[12],v[4] }},
                { 3, new Vector3[] {v[8],v[17],v[51],v[51],v[16],v[8] }},
                { 5, new Vector3[] {v[43],v[12],v[51],v[51],v[114],v[43],v[18],v[115],v[119],v[119],v[44],v[18] }},
                { 0, new Vector3[] {v[2],v[44],v[119],v[119],v[100],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[7],v[103],v[122],v[122],v[46],v[7],v[4],v[47],v[124],v[124],v[10],v[4],v[4],v[10],v[5] }},
                { 7, new Vector3[] {v[68],v[114],v[122],v[122],v[103],v[68],v[19],v[10],v[124],v[124],v[115],v[19],v[19],v[14],v[10] }},
                { 5, new Vector3[] {v[43],v[46],v[122],v[122],v[114],v[43],v[3],v[18],v[115],v[115],v[47],v[3] }},
                { 3, new Vector3[] {v[1],v[5],v[10],v[10],v[14],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[47],v[66],v[66],v[11],v[4],v[7],v[103],v[118],v[118],v[46],v[7] }},
                { 5, new Vector3[] {v[3],v[45],v[66],v[66],v[47],v[3],v[43],v[46],v[118],v[118],v[114],v[43],v[18],v[115],v[116],v[116],v[44],v[18] }},
                { 0, new Vector3[] {v[0],v[11],v[66],v[66],v[45],v[0],v[2],v[44],v[116],v[116],v[100],v[2] }},
                { 7, new Vector3[] {v[68],v[114],v[118],v[118],v[103],v[68],v[19],v[100],v[116],v[116],v[115],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[18],v[115],v[30],v[30],v[6],v[18],v[43],v[46],v[125],v[125],v[114],v[43] }},
                { 3, new Vector3[] {v[1],v[15],v[30],v[30],v[14],v[1] }},
                { 1, new Vector3[] {v[0],v[6],v[30],v[30],v[15],v[0] }},
                { 7, new Vector3[] {v[19],v[14],v[30],v[30],v[115],v[19],v[68],v[114],v[125],v[125],v[103],v[68] }},
                { 2, new Vector3[] {v[7],v[103],v[125],v[125],v[46],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[43],v[46],v[118],v[118],v[114],v[43],v[18],v[115],v[119],v[119],v[44],v[18] }},
                { 2, new Vector3[] {v[7],v[103],v[118],v[118],v[46],v[7] }},
                { 7, new Vector3[] {v[68],v[114],v[118],v[118],v[103],v[68],v[19],v[100],v[119],v[119],v[115],v[19] }},
                { 0, new Vector3[] {v[2],v[44],v[119],v[119],v[100],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[68],v[114],v[10],v[10],v[13],v[68],v[13],v[10],v[14] }},
                { 5, new Vector3[] {v[114],v[43],v[3],v[3],v[10],v[114],v[3],v[6],v[10] }},
                { 4, new Vector3[] {v[2],v[14],v[10],v[10],v[6],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[101],v[13],v[10],v[13],v[68],v[10],v[68],v[114],v[10] }},
                { 5, new Vector3[] {v[114],v[43],v[10],v[43],v[3],v[10],v[3],v[45],v[10] }},
                { 0, new Vector3[] {v[45],v[0],v[10],v[0],v[1],v[10],v[1],v[101],v[10] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[21],v[53],v[0],v[53],v[79],v[79],v[40],v[0],v[4],v[0],v[40],v[40],v[12],v[4] }},
                { 4, new Vector3[] {v[2],v[14],v[53],v[53],v[21],v[2] }},
                { 7, new Vector3[] {v[13],v[53],v[14],v[13],v[68],v[114],v[114],v[53],v[13] }},
                { 5, new Vector3[] {v[43],v[40],v[79],v[79],v[114],v[43],v[43],v[12],v[40] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[13],v[68],v[114],v[114],v[101],v[13] }},
                { 0, new Vector3[] {v[1],v[101],v[117],v[117],v[10],v[1],v[1],v[10],v[5] }},
                { 5, new Vector3[] {v[43],v[10],v[117],v[117],v[114],v[43],v[43],v[12],v[10] }},
                { 1, new Vector3[] {v[4],v[5],v[10],v[10],v[12],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[43],v[46],v[118],v[118],v[114],v[43],v[3],v[10],v[126],v[126],v[47],v[3],v[3],v[6],v[10] }},
                { 2, new Vector3[] {v[7],v[103],v[118],v[118],v[46],v[7],v[8],v[4],v[47],v[47],v[102],v[8] }},
                { 7, new Vector3[] {v[68],v[114],v[118],v[118],v[103],v[68],v[13],v[102],v[126],v[126],v[10],v[13],v[13],v[10],v[14] }},
                { 4, new Vector3[] {v[2],v[14],v[10],v[10],v[6],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[11],v[48],v[48],v[45],v[0],v[1],v[101],v[104],v[104],v[9],v[1] }},
                { 2, new Vector3[] {v[4],v[47],v[48],v[48],v[11],v[4],v[8],v[9],v[104],v[104],v[102],v[8],v[7],v[103],v[118],v[118],v[46],v[7] }},
                { 5, new Vector3[] {v[3],v[45],v[48],v[48],v[47],v[3],v[43],v[46],v[118],v[118],v[114],v[43] }},
                { 7, new Vector3[] {v[13],v[102],v[104],v[104],v[101],v[13],v[68],v[114],v[118],v[118],v[103],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[13],v[102],v[53],v[53],v[14],v[13],v[68],v[114],v[122],v[122],v[103],v[68] }},
                { 1, new Vector3[] {v[0],v[21],v[53],v[53],v[5],v[0] }},
                { 4, new Vector3[] {v[2],v[14],v[53],v[53],v[21],v[2] }},
                { 2, new Vector3[] {v[8],v[5],v[53],v[53],v[102],v[8],v[7],v[103],v[122],v[122],v[46],v[7] }},
                { 5, new Vector3[] {v[43],v[46],v[122],v[122],v[114],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[8],v[9],v[104],v[104],v[102],v[8],v[7],v[103],v[122],v[122],v[46],v[7] }},
                { 0, new Vector3[] {v[1],v[101],v[104],v[104],v[9],v[1] }},
                { 7, new Vector3[] {v[13],v[102],v[104],v[104],v[101],v[13],v[68],v[114],v[122],v[122],v[103],v[68] }},
                { 5, new Vector3[] {v[43],v[46],v[122],v[122],v[114],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[43],v[3],v[6],v[6],v[29],v[43],v[43],v[29],v[56],v[56],v[51],v[43],v[43],v[51],v[114] }},
                { 4, new Vector3[] {v[2],v[29],v[6],v[2],v[35],v[56],v[56],v[29],v[2] }},
                { 3, new Vector3[] {v[1],v[8],v[51],v[51],v[35],v[1],v[8],v[17],v[51] }},
                { 7, new Vector3[] {v[68],v[114],v[51],v[51],v[17],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[43],v[3],v[45],v[45],v[114],v[43] }},
                { 7, new Vector3[] {v[68],v[114],v[123],v[123],v[10],v[68],v[68],v[10],v[17] }},
                { 0, new Vector3[] {v[0],v[10],v[123],v[123],v[45],v[0],v[0],v[5],v[10] }},
                { 3, new Vector3[] {v[8],v[17],v[10],v[10],v[5],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[16],v[51],v[51],v[12],v[4],v[0],v[21],v[99],v[99],v[15],v[0] }},
                { 7, new Vector3[] {v[68],v[114],v[51],v[51],v[17],v[68] }},
                { 5, new Vector3[] {v[43],v[12],v[51],v[51],v[114],v[43] }},
                { 3, new Vector3[] {v[8],v[17],v[51],v[51],v[16],v[8],v[1],v[15],v[99],v[99],v[35],v[1] }},
                { 4, new Vector3[] {v[2],v[35],v[99],v[99],v[21],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[16],v[51],v[51],v[12],v[4] }},
                { 7, new Vector3[] {v[68],v[114],v[51],v[51],v[17],v[68] }},
                { 5, new Vector3[] {v[43],v[12],v[51],v[51],v[114],v[43] }},
                { 3, new Vector3[] {v[8],v[17],v[51],v[51],v[16],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[47],v[65],v[65],v[5],v[4],v[7],v[103],v[118],v[118],v[46],v[7] }},
                { 4, new Vector3[] {v[2],v[35],v[65],v[65],v[6],v[2] }},
                { 3, new Vector3[] {v[1],v[5],v[65],v[65],v[35],v[1] }},
                { 5, new Vector3[] {v[3],v[6],v[65],v[65],v[47],v[3],v[43],v[46],v[118],v[118],v[114],v[43] }},
                { 7, new Vector3[] {v[68],v[114],v[118],v[118],v[103],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[45],v[60],v[60],v[47],v[3],v[43],v[46],v[118],v[118],v[114],v[43] }},
                { 0, new Vector3[] {v[0],v[11],v[60],v[60],v[45],v[0] }},
                { 2, new Vector3[] {v[4],v[47],v[60],v[60],v[11],v[4],v[7],v[103],v[118],v[118],v[46],v[7] }},
                { 7, new Vector3[] {v[68],v[114],v[118],v[118],v[103],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[21],v[36],v[36],v[15],v[0] }},
                { 4, new Vector3[] {v[2],v[35],v[36],v[36],v[21],v[2] }},
                { 3, new Vector3[] {v[1],v[15],v[36],v[36],v[35],v[1] }},
                { 5, new Vector3[] {v[43],v[46],v[118],v[118],v[114],v[43] }},
                { 2, new Vector3[] {v[7],v[103],v[118],v[118],v[46],v[7] }},
                { 7, new Vector3[] {v[68],v[114],v[118],v[118],v[103],v[68] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[7],v[103],v[122],v[122],v[46],v[7] }},
                { 7, new Vector3[] {v[68],v[114],v[122],v[122],v[103],v[68] }},
                { 5, new Vector3[] {v[43],v[46],v[122],v[122],v[114],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[13],v[17],v[57],v[57],v[19],v[13] }},
                { 6, new Vector3[] {v[17],v[7],v[43],v[43],v[57],v[17] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[13],v[17],v[127],v[127],v[53],v[13],v[13],v[53],v[101],v[19],v[100],v[30],v[19],v[30],v[128],v[128],v[57],v[19] }},
                { 6, new Vector3[] {v[7],v[24],v[127],v[127],v[17],v[7],v[7],v[43],v[40],v[40],v[24],v[7],v[43],v[57],v[128],v[128],v[40],v[43] }},
                { 0, new Vector3[] {v[0],v[53],v[127],v[127],v[24],v[0],v[0],v[1],v[101],v[101],v[53],v[0],v[0],v[24],v[40],v[2],v[0],v[30],v[30],v[100],v[2],v[0],v[40],v[128],v[128],v[30],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[43],v[57],v[128],v[128],v[40],v[43],v[43],v[40],v[70],v[7],v[69],v[24],v[7],v[24],v[127],v[127],v[17],v[7] }},
                { 7, new Vector3[] {v[19],v[30],v[128],v[128],v[57],v[19],v[19],v[13],v[53],v[53],v[30],v[19],v[13],v[17],v[127],v[127],v[53],v[13] }},
                { 1, new Vector3[] {v[0],v[40],v[128],v[128],v[30],v[0],v[0],v[3],v[70],v[70],v[40],v[0],v[0],v[30],v[53],v[4],v[0],v[24],v[24],v[69],v[4],v[0],v[53],v[127],v[127],v[24],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[70],v[29],v[29],v[6],v[3],v[4],v[5],v[23],v[23],v[69],v[4] }},
                { 6, new Vector3[] {v[43],v[57],v[29],v[29],v[70],v[43],v[7],v[69],v[23],v[23],v[17],v[7] }},
                { 0, new Vector3[] {v[2],v[6],v[29],v[29],v[100],v[2],v[1],v[101],v[23],v[23],v[5],v[1] }},
                { 7, new Vector3[] {v[19],v[100],v[29],v[29],v[57],v[19],v[13],v[17],v[23],v[23],v[101],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[13],v[102],v[10],v[10],v[19],v[13],v[19],v[10],v[57] }},
                { 2, new Vector3[] {v[102],v[8],v[4],v[4],v[10],v[102],v[4],v[12],v[10] }},
                { 6, new Vector3[] {v[43],v[57],v[10],v[10],v[12],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[8],v[9],v[104],v[104],v[102],v[8],v[4],v[10],v[129],v[129],v[11],v[4],v[4],v[12],v[10] }},
                { 0, new Vector3[] {v[1],v[101],v[104],v[104],v[9],v[1],v[2],v[0],v[11],v[11],v[100],v[2] }},
                { 7, new Vector3[] {v[13],v[102],v[104],v[104],v[101],v[13],v[19],v[100],v[129],v[129],v[10],v[19],v[19],v[10],v[57] }},
                { 6, new Vector3[] {v[43],v[57],v[10],v[10],v[12],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[70],v[29],v[3],v[29],v[63],v[63],v[24],v[3],v[0],v[3],v[24],v[24],v[5],v[0] }},
                { 6, new Vector3[] {v[43],v[57],v[29],v[29],v[70],v[43] }},
                { 7, new Vector3[] {v[19],v[29],v[57],v[19],v[13],v[102],v[102],v[29],v[19] }},
                { 2, new Vector3[] {v[8],v[24],v[63],v[63],v[102],v[8],v[8],v[5],v[24] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[19],v[100],v[29],v[29],v[57],v[19],v[13],v[102],v[110],v[110],v[101],v[13] }},
                { 1, new Vector3[] {v[3],v[70],v[29],v[29],v[6],v[3] }},
                { 6, new Vector3[] {v[43],v[57],v[29],v[29],v[70],v[43] }},
                { 0, new Vector3[] {v[2],v[6],v[29],v[29],v[100],v[2],v[1],v[101],v[110],v[110],v[9],v[1] }},
                { 2, new Vector3[] {v[8],v[9],v[110],v[110],v[102],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[8],v[76],v[10],v[10],v[1],v[8],v[1],v[10],v[14] }},
                { 6, new Vector3[] {v[76],v[7],v[43],v[43],v[10],v[76],v[43],v[57],v[10] }},
                { 7, new Vector3[] {v[19],v[14],v[10],v[10],v[57],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[2],v[0],v[5],v[5],v[53],v[2],v[2],v[53],v[62],v[62],v[29],v[2],v[2],v[29],v[100] }},
                { 3, new Vector3[] {v[8],v[53],v[5],v[8],v[76],v[62],v[62],v[53],v[8] }},
                { 6, new Vector3[] {v[7],v[43],v[29],v[29],v[76],v[7],v[43],v[57],v[29] }},
                { 7, new Vector3[] {v[19],v[100],v[29],v[29],v[57],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[7],v[69],v[91],v[91],v[76],v[7],v[43],v[10],v[130],v[130],v[70],v[43],v[43],v[57],v[10] }},
                { 1, new Vector3[] {v[4],v[16],v[91],v[91],v[69],v[4],v[0],v[3],v[70],v[70],v[15],v[0] }},
                { 3, new Vector3[] {v[8],v[76],v[91],v[91],v[16],v[8],v[1],v[15],v[130],v[130],v[10],v[1],v[1],v[10],v[14] }},
                { 7, new Vector3[] {v[19],v[14],v[10],v[10],v[57],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[70],v[29],v[29],v[6],v[3],v[4],v[16],v[91],v[91],v[69],v[4] }},
                { 7, new Vector3[] {v[19],v[100],v[29],v[29],v[57],v[19] }},
                { 0, new Vector3[] {v[2],v[6],v[29],v[29],v[100],v[2] }},
                { 6, new Vector3[] {v[43],v[57],v[29],v[29],v[70],v[43],v[7],v[69],v[91],v[91],v[76],v[7] }},
                { 3, new Vector3[] {v[8],v[76],v[91],v[91],v[16],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[12],v[10],v[10],v[5],v[4] }},
                { 6, new Vector3[] {v[43],v[57],v[10],v[10],v[12],v[43] }},
                { 3, new Vector3[] {v[1],v[5],v[10],v[10],v[14],v[1] }},
                { 7, new Vector3[] {v[19],v[14],v[10],v[10],v[57],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[2],v[0],v[11],v[11],v[100],v[2] }},
                { 7, new Vector3[] {v[19],v[100],v[129],v[129],v[10],v[19],v[19],v[10],v[57] }},
                { 2, new Vector3[] {v[4],v[10],v[129],v[129],v[11],v[4],v[4],v[12],v[10] }},
                { 6, new Vector3[] {v[43],v[57],v[10],v[10],v[12],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[3],v[70],v[70],v[15],v[0] }},
                { 3, new Vector3[] {v[1],v[15],v[130],v[130],v[10],v[1],v[1],v[10],v[14] }},
                { 6, new Vector3[] {v[43],v[10],v[130],v[130],v[70],v[43],v[43],v[57],v[10] }},
                { 7, new Vector3[] {v[19],v[14],v[10],v[10],v[57],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[70],v[29],v[29],v[6],v[3] }},
                { 7, new Vector3[] {v[19],v[100],v[29],v[29],v[57],v[19] }},
                { 0, new Vector3[] {v[2],v[6],v[29],v[29],v[100],v[2] }},
                { 6, new Vector3[] {v[43],v[57],v[29],v[29],v[70],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[43],v[81],v[10],v[10],v[7],v[43],v[7],v[10],v[17] }},
                { 4, new Vector3[] {v[81],v[18],v[2],v[2],v[10],v[81],v[2],v[14],v[10] }},
                { 7, new Vector3[] {v[13],v[17],v[10],v[10],v[14],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[43],v[81],v[40],v[43],v[40],v[56],v[56],v[26],v[43],v[7],v[43],v[26],v[26],v[17],v[7] }},
                { 4, new Vector3[] {v[18],v[6],v[40],v[40],v[81],v[18] }},
                { 0, new Vector3[] {v[0],v[40],v[6],v[0],v[1],v[101],v[101],v[40],v[0] }},
                { 7, new Vector3[] {v[13],v[26],v[56],v[56],v[101],v[13],v[13],v[17],v[26] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[18],v[20],v[90],v[90],v[81],v[18],v[2],v[10],v[131],v[131],v[21],v[2],v[2],v[14],v[10] }},
                { 1, new Vector3[] {v[3],v[70],v[90],v[90],v[20],v[3],v[4],v[0],v[21],v[21],v[69],v[4] }},
                { 6, new Vector3[] {v[43],v[81],v[90],v[90],v[70],v[43],v[7],v[69],v[131],v[131],v[10],v[7],v[7],v[10],v[17] }},
                { 7, new Vector3[] {v[13],v[17],v[10],v[10],v[14],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[7],v[69],v[23],v[23],v[17],v[7],v[43],v[81],v[82],v[82],v[70],v[43] }},
                { 0, new Vector3[] {v[1],v[101],v[23],v[23],v[5],v[1] }},
                { 7, new Vector3[] {v[13],v[17],v[23],v[23],v[101],v[13] }},
                { 1, new Vector3[] {v[4],v[5],v[23],v[23],v[69],v[4],v[3],v[70],v[82],v[82],v[20],v[3] }},
                { 4, new Vector3[] {v[18],v[20],v[82],v[82],v[81],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[8],v[4],v[12],v[12],v[51],v[8],v[8],v[51],v[33],v[33],v[53],v[8],v[8],v[53],v[102] }},
                { 6, new Vector3[] {v[43],v[51],v[12],v[43],v[81],v[33],v[33],v[51],v[43] }},
                { 4, new Vector3[] {v[18],v[2],v[53],v[53],v[81],v[18],v[2],v[14],v[53] }},
                { 7, new Vector3[] {v[13],v[102],v[53],v[53],v[14],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[11],v[40],v[40],v[6],v[0],v[1],v[101],v[104],v[104],v[9],v[1] }},
                { 6, new Vector3[] {v[43],v[81],v[40],v[40],v[12],v[43] }},
                { 4, new Vector3[] {v[18],v[6],v[40],v[40],v[81],v[18] }},
                { 2, new Vector3[] {v[4],v[12],v[40],v[40],v[11],v[4],v[8],v[9],v[104],v[104],v[102],v[8] }},
                { 7, new Vector3[] {v[13],v[102],v[104],v[104],v[101],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[21],v[53],v[53],v[5],v[0],v[3],v[70],v[90],v[90],v[20],v[3] }},
                { 7, new Vector3[] {v[13],v[102],v[53],v[53],v[14],v[13] }},
                { 2, new Vector3[] {v[8],v[5],v[53],v[53],v[102],v[8] }},
                { 4, new Vector3[] {v[2],v[14],v[53],v[53],v[21],v[2],v[18],v[20],v[90],v[90],v[81],v[18] }},
                { 6, new Vector3[] {v[43],v[81],v[90],v[90],v[70],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[70],v[82],v[82],v[20],v[3] }},
                { 6, new Vector3[] {v[43],v[81],v[82],v[82],v[70],v[43] }},
                { 4, new Vector3[] {v[18],v[20],v[82],v[82],v[81],v[18] }},
                { 2, new Vector3[] {v[8],v[9],v[104],v[104],v[102],v[8] }},
                { 0, new Vector3[] {v[1],v[101],v[104],v[104],v[9],v[1] }},
                { 7, new Vector3[] {v[13],v[102],v[104],v[104],v[101],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[76],v[7],v[10],v[7],v[43],v[10],v[43],v[81],v[10] }},
                { 4, new Vector3[] {v[81],v[18],v[10],v[18],v[2],v[10],v[2],v[35],v[10] }},
                { 3, new Vector3[] {v[35],v[1],v[10],v[1],v[8],v[10],v[8],v[76],v[10] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {v[7],v[43],v[81],v[81],v[76],v[7] }},
                { 3, new Vector3[] {v[8],v[76],v[88],v[88],v[10],v[8],v[8],v[10],v[5] }},
                { 4, new Vector3[] {v[18],v[10],v[88],v[88],v[81],v[18],v[18],v[6],v[10] }},
                { 0, new Vector3[] {v[0],v[5],v[10],v[10],v[6],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[1],v[15],v[99],v[99],v[35],v[1],v[8],v[76],v[77],v[77],v[16],v[8] }},
                { 1, new Vector3[] {v[0],v[21],v[99],v[99],v[15],v[0],v[4],v[16],v[77],v[77],v[69],v[4],v[3],v[70],v[90],v[90],v[20],v[3] }},
                { 4, new Vector3[] {v[2],v[35],v[99],v[99],v[21],v[2],v[18],v[20],v[90],v[90],v[81],v[18] }},
                { 6, new Vector3[] {v[7],v[69],v[77],v[77],v[76],v[7],v[43],v[81],v[90],v[90],v[70],v[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[16],v[77],v[77],v[69],v[4],v[3],v[70],v[82],v[82],v[20],v[3] }},
                { 3, new Vector3[] {v[8],v[76],v[77],v[77],v[16],v[8] }},
                { 6, new Vector3[] {v[7],v[69],v[77],v[77],v[76],v[7],v[43],v[81],v[82],v[82],v[70],v[43] }},
                { 4, new Vector3[] {v[18],v[20],v[82],v[82],v[81],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {v[18],v[2],v[35],v[35],v[81],v[18] }},
                { 6, new Vector3[] {v[43],v[81],v[92],v[92],v[10],v[43],v[43],v[10],v[12] }},
                { 3, new Vector3[] {v[1],v[10],v[92],v[92],v[35],v[1],v[1],v[5],v[10] }},
                { 2, new Vector3[] {v[4],v[12],v[10],v[10],v[5],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[11],v[40],v[40],v[6],v[0] }},
                { 6, new Vector3[] {v[43],v[81],v[40],v[40],v[12],v[43] }},
                { 4, new Vector3[] {v[18],v[6],v[40],v[40],v[81],v[18] }},
                { 2, new Vector3[] {v[4],v[12],v[40],v[40],v[11],v[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[70],v[82],v[82],v[20],v[3],v[0],v[21],v[36],v[36],v[15],v[0] }},
                { 6, new Vector3[] {v[43],v[81],v[82],v[82],v[70],v[43] }},
                { 4, new Vector3[] {v[18],v[20],v[82],v[82],v[81],v[18],v[2],v[35],v[36],v[36],v[21],v[2] }},
                { 3, new Vector3[] {v[1],v[15],v[36],v[36],v[35],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[3],v[70],v[82],v[82],v[20],v[3] }},
                { 6, new Vector3[] {v[43],v[81],v[82],v[82],v[70],v[43] }},
                { 4, new Vector3[] {v[18],v[20],v[82],v[82],v[81],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[18],v[115],v[10],v[10],v[3],v[18],v[3],v[10],v[12] }},
                { 7, new Vector3[] {v[115],v[19],v[13],v[13],v[10],v[115],v[13],v[17],v[10] }},
                { 6, new Vector3[] {v[7],v[12],v[10],v[10],v[17],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[18],v[115],v[119],v[119],v[44],v[18],v[3],v[45],v[132],v[132],v[10],v[3],v[3],v[10],v[12] }},
                { 7, new Vector3[] {v[19],v[100],v[119],v[119],v[115],v[19],v[13],v[10],v[132],v[132],v[101],v[13],v[13],v[17],v[10] }},
                { 0, new Vector3[] {v[2],v[44],v[119],v[119],v[100],v[2],v[0],v[1],v[101],v[101],v[45],v[0] }},
                { 6, new Vector3[] {v[7],v[12],v[10],v[10],v[17],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[23],v[69],v[4],v[40],v[41],v[41],v[23],v[4],v[4],v[0],v[6],v[6],v[40],v[4] }},
                { 7, new Vector3[] {v[13],v[17],v[23],v[19],v[13],v[23],v[23],v[115],v[19] }},
                { 6, new Vector3[] {v[7],v[69],v[23],v[23],v[17],v[7] }},
                { 5, new Vector3[] {v[18],v[115],v[41],v[41],v[40],v[18],v[18],v[40],v[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[1],v[101],v[23],v[23],v[5],v[1],v[2],v[44],v[121],v[121],v[100],v[2] }},
                { 6, new Vector3[] {v[7],v[69],v[23],v[23],v[17],v[7] }},
                { 1, new Vector3[] {v[4],v[5],v[23],v[23],v[69],v[4] }},
                { 7, new Vector3[] {v[13],v[17],v[23],v[23],v[101],v[13],v[19],v[100],v[121],v[121],v[115],v[19] }},
                { 5, new Vector3[] {v[18],v[115],v[121],v[121],v[44],v[18] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[115],v[19],v[10],v[19],v[13],v[10],v[13],v[102],v[10] }},
                { 2, new Vector3[] {v[102],v[8],v[10],v[8],v[4],v[10],v[4],v[47],v[10] }},
                { 5, new Vector3[] {v[47],v[3],v[10],v[3],v[18],v[10],v[18],v[115],v[10] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[45],v[60],v[60],v[47],v[3],v[18],v[115],v[116],v[116],v[44],v[18] }},
                { 0, new Vector3[] {v[0],v[11],v[60],v[60],v[45],v[0],v[2],v[44],v[116],v[116],v[100],v[2],v[1],v[101],v[104],v[104],v[9],v[1] }},
                { 2, new Vector3[] {v[4],v[47],v[60],v[60],v[11],v[4],v[8],v[9],v[104],v[104],v[102],v[8] }},
                { 7, new Vector3[] {v[19],v[100],v[116],v[116],v[115],v[19],v[13],v[102],v[104],v[104],v[101],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {v[19],v[13],v[102],v[102],v[115],v[19] }},
                { 5, new Vector3[] {v[18],v[115],v[120],v[120],v[10],v[18],v[18],v[10],v[6] }},
                { 2, new Vector3[] {v[8],v[10],v[120],v[120],v[102],v[8],v[8],v[5],v[10] }},
                { 1, new Vector3[] {v[0],v[6],v[10],v[10],v[5],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[2],v[44],v[116],v[116],v[100],v[2],v[1],v[101],v[110],v[110],v[9],v[1] }},
                { 5, new Vector3[] {v[18],v[115],v[116],v[116],v[44],v[18] }},
                { 7, new Vector3[] {v[19],v[100],v[116],v[116],v[115],v[19],v[13],v[102],v[110],v[110],v[101],v[13] }},
                { 2, new Vector3[] {v[8],v[9],v[110],v[110],v[102],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[8],v[76],v[24],v[8],v[24],v[33],v[33],v[32],v[8],v[1],v[8],v[32],v[32],v[14],v[1] }},
                { 6, new Vector3[] {v[7],v[12],v[24],v[24],v[76],v[7] }},
                { 5, new Vector3[] {v[3],v[24],v[12],v[3],v[18],v[115],v[115],v[24],v[3] }},
                { 7, new Vector3[] {v[19],v[32],v[33],v[33],v[115],v[19],v[19],v[14],v[32] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[45],v[24],v[24],v[12],v[3],v[18],v[115],v[116],v[116],v[44],v[18] }},
                { 3, new Vector3[] {v[8],v[76],v[24],v[24],v[5],v[8] }},
                { 6, new Vector3[] {v[7],v[12],v[24],v[24],v[76],v[7] }},
                { 0, new Vector3[] {v[0],v[5],v[24],v[24],v[45],v[0],v[2],v[44],v[116],v[116],v[100],v[2] }},
                { 7, new Vector3[] {v[19],v[100],v[116],v[116],v[115],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[1],v[15],v[30],v[30],v[14],v[1],v[8],v[76],v[77],v[77],v[16],v[8] }},
                { 5, new Vector3[] {v[18],v[115],v[30],v[30],v[6],v[18] }},
                { 7, new Vector3[] {v[19],v[14],v[30],v[30],v[115],v[19] }},
                { 1, new Vector3[] {v[0],v[6],v[30],v[30],v[15],v[0],v[4],v[16],v[77],v[77],v[69],v[4] }},
                { 6, new Vector3[] {v[7],v[69],v[77],v[77],v[76],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[16],v[77],v[77],v[69],v[4] }},
                { 3, new Vector3[] {v[8],v[76],v[77],v[77],v[16],v[8] }},
                { 6, new Vector3[] {v[7],v[69],v[77],v[77],v[76],v[7] }},
                { 0, new Vector3[] {v[2],v[44],v[116],v[116],v[100],v[2] }},
                { 5, new Vector3[] {v[18],v[115],v[116],v[116],v[44],v[18] }},
                { 7, new Vector3[] {v[19],v[100],v[116],v[116],v[115],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[18],v[115],v[115],v[47],v[3] }},
                { 2, new Vector3[] {v[4],v[47],v[124],v[124],v[10],v[4],v[4],v[10],v[5] }},
                { 7, new Vector3[] {v[19],v[10],v[124],v[124],v[115],v[19],v[19],v[14],v[10] }},
                { 3, new Vector3[] {v[1],v[5],v[10],v[10],v[14],v[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[11],v[48],v[48],v[45],v[0],v[2],v[44],v[116],v[116],v[100],v[2] }},
                { 2, new Vector3[] {v[4],v[47],v[48],v[48],v[11],v[4] }},
                { 5, new Vector3[] {v[3],v[45],v[48],v[48],v[47],v[3],v[18],v[115],v[116],v[116],v[44],v[18] }},
                { 7, new Vector3[] {v[19],v[100],v[116],v[116],v[115],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[18],v[115],v[30],v[30],v[6],v[18] }},
                { 3, new Vector3[] {v[1],v[15],v[30],v[30],v[14],v[1] }},
                { 1, new Vector3[] {v[0],v[6],v[30],v[30],v[15],v[0] }},
                { 7, new Vector3[] {v[19],v[14],v[30],v[30],v[115],v[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[18],v[115],v[119],v[119],v[44],v[18] }},
                { 7, new Vector3[] {v[19],v[100],v[119],v[119],v[115],v[19] }},
                { 0, new Vector3[] {v[2],v[44],v[119],v[119],v[100],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[6],v[10],v[10],v[12],v[3] }},
                { 4, new Vector3[] {v[2],v[14],v[10],v[10],v[6],v[2] }},
                { 6, new Vector3[] {v[7],v[12],v[10],v[10],v[17],v[7] }},
                { 7, new Vector3[] {v[13],v[17],v[10],v[10],v[14],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[1],v[101],v[101],v[45],v[0] }},
                { 5, new Vector3[] {v[3],v[45],v[132],v[132],v[10],v[3],v[3],v[10],v[12] }},
                { 7, new Vector3[] {v[13],v[10],v[132],v[132],v[101],v[13],v[13],v[17],v[10] }},
                { 6, new Vector3[] {v[7],v[12],v[10],v[10],v[17],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[0],v[21],v[21],v[69],v[4] }},
                { 6, new Vector3[] {v[7],v[69],v[131],v[131],v[10],v[7],v[7],v[10],v[17] }},
                { 4, new Vector3[] {v[2],v[10],v[131],v[131],v[21],v[2],v[2],v[14],v[10] }},
                { 7, new Vector3[] {v[13],v[17],v[10],v[10],v[14],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[1],v[101],v[23],v[23],v[5],v[1] }},
                { 6, new Vector3[] {v[7],v[69],v[23],v[23],v[17],v[7] }},
                { 1, new Vector3[] {v[4],v[5],v[23],v[23],v[69],v[4] }},
                { 7, new Vector3[] {v[13],v[17],v[23],v[23],v[101],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[8],v[4],v[47],v[47],v[102],v[8] }},
                { 7, new Vector3[] {v[13],v[102],v[126],v[126],v[10],v[13],v[13],v[10],v[14] }},
                { 5, new Vector3[] {v[3],v[10],v[126],v[126],v[47],v[3],v[3],v[6],v[10] }},
                { 4, new Vector3[] {v[2],v[14],v[10],v[10],v[6],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[47],v[66],v[66],v[11],v[4],v[8],v[9],v[104],v[104],v[102],v[8] }},
                { 5, new Vector3[] {v[3],v[45],v[66],v[66],v[47],v[3] }},
                { 0, new Vector3[] {v[0],v[11],v[66],v[66],v[45],v[0],v[1],v[101],v[104],v[104],v[9],v[1] }},
                { 7, new Vector3[] {v[13],v[102],v[104],v[104],v[101],v[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[21],v[53],v[53],v[5],v[0] }},
                { 7, new Vector3[] {v[13],v[102],v[53],v[53],v[14],v[13] }},
                { 2, new Vector3[] {v[8],v[5],v[53],v[53],v[102],v[8] }},
                { 4, new Vector3[] {v[2],v[14],v[53],v[53],v[21],v[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[1],v[101],v[110],v[110],v[9],v[1] }},
                { 7, new Vector3[] {v[13],v[102],v[110],v[110],v[101],v[13] }},
                { 2, new Vector3[] {v[8],v[9],v[110],v[110],v[102],v[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {v[1],v[8],v[76],v[76],v[35],v[1] }},
                { 4, new Vector3[] {v[2],v[35],v[98],v[98],v[10],v[2],v[2],v[10],v[6] }},
                { 6, new Vector3[] {v[7],v[10],v[98],v[98],v[76],v[7],v[7],v[12],v[10] }},
                { 5, new Vector3[] {v[3],v[6],v[10],v[10],v[12],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {v[3],v[45],v[24],v[24],v[12],v[3] }},
                { 3, new Vector3[] {v[8],v[76],v[24],v[24],v[5],v[8] }},
                { 6, new Vector3[] {v[7],v[12],v[24],v[24],v[76],v[7] }},
                { 0, new Vector3[] {v[0],v[5],v[24],v[24],v[45],v[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[21],v[36],v[36],v[15],v[0],v[4],v[16],v[77],v[77],v[69],v[4] }},
                { 4, new Vector3[] {v[2],v[35],v[36],v[36],v[21],v[2] }},
                { 3, new Vector3[] {v[1],v[15],v[36],v[36],v[35],v[1],v[8],v[76],v[77],v[77],v[16],v[8] }},
                { 6, new Vector3[] {v[7],v[69],v[77],v[77],v[76],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[4],v[16],v[77],v[77],v[69],v[4] }},
                { 3, new Vector3[] {v[8],v[76],v[77],v[77],v[16],v[8] }},
                { 6, new Vector3[] {v[7],v[69],v[77],v[77],v[76],v[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {v[4],v[47],v[65],v[65],v[5],v[4] }},
                { 4, new Vector3[] {v[2],v[35],v[65],v[65],v[6],v[2] }},
                { 3, new Vector3[] {v[1],v[5],v[65],v[65],v[35],v[1] }},
                { 5, new Vector3[] {v[3],v[6],v[65],v[65],v[47],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {v[0],v[11],v[48],v[48],v[45],v[0] }},
                { 2, new Vector3[] {v[4],v[47],v[48],v[48],v[11],v[4] }},
                { 5, new Vector3[] {v[3],v[45],v[48],v[48],v[47],v[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {v[0],v[21],v[36],v[36],v[15],v[0] }},
                { 4, new Vector3[] {v[2],v[35],v[36],v[36],v[21],v[2] }},
                { 3, new Vector3[] {v[1],v[15],v[36],v[36],v[35],v[1] }}
            },
                        new Dictionary<int, Vector3[]>()
                };
    private static readonly Dictionary<int, Vector3[]>[] normalTable = new Dictionary<int, Vector3[]>[]
    {
            new Dictionary<int, Vector3[]>(),
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2] }},
                { 0, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 0, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[4],n[4],n[4],n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5] }},
                { 2, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[6],n[6],n[6] }},
                { 0, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[6],n[6],n[6] }},
                { 1, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 3, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 1, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[6],n[6],n[6] }},
                { 3, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[6],n[6],n[6] }},
                { 0, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }},
                { 2, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[6],n[6],n[6] }},
                { 2, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[6],n[6],n[6] }},
                { 3, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[6],n[6],n[6] }},
                { 1, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[6],n[6],n[6] }},
                { 2, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }},
                { 2, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }},
                { 0, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }},
                { 3, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[9],n[9],n[9] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }},
                { 0, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 1, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[11],n[11],n[11],n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[12],n[12],n[12] }},
                { 1, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[12],n[12],n[12] }},
                { 0, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[3],n[3],n[3] }},
                { 4, new Vector3[] {n[9],n[9],n[9] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[13],n[13],n[13],n[13],n[13],n[13],n[1],n[1],n[1],n[4],n[4],n[4],n[14],n[14],n[14],n[14],n[14],n[14] }},
                { 4, new Vector3[] {n[13],n[13],n[13],n[13],n[13],n[13],n[15],n[15],n[15],n[15],n[15],n[15],n[14],n[14],n[14],n[14],n[14],n[14] }},
                { 2, new Vector3[] {n[13],n[13],n[13],n[13],n[13],n[13],n[1],n[1],n[1],n[1],n[1],n[1],n[15],n[15],n[15],n[4],n[4],n[4],n[4],n[4],n[4],n[14],n[14],n[14],n[14],n[14],n[14] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[16],n[16],n[16],n[16],n[16],n[16],n[0],n[0],n[0],n[11],n[11],n[11],n[17],n[17],n[17],n[17],n[17],n[17] }},
                { 2, new Vector3[] {n[16],n[16],n[16],n[16],n[16],n[16],n[18],n[18],n[18],n[18],n[18],n[18],n[17],n[17],n[17],n[17],n[17],n[17] }},
                { 4, new Vector3[] {n[16],n[16],n[16],n[16],n[16],n[16],n[0],n[0],n[0],n[0],n[0],n[0],n[18],n[18],n[18],n[11],n[11],n[11],n[11],n[11],n[11],n[17],n[17],n[17],n[17],n[17],n[17] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5],n[0],n[0],n[0],n[0],n[0],n[0],n[19],n[19],n[19] }},
                { 1, new Vector3[] {n[5],n[5],n[5],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 4, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[19],n[19],n[19] }},
                { 0, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 4, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[20],n[20],n[20],n[20],n[20],n[20] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[21],n[21],n[21] }},
                { 4, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[21],n[21],n[21] }},
                { 0, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 1, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 3, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 1, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 3, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[23],n[23],n[23],n[23],n[23],n[23],n[20],n[20],n[20],n[0],n[0],n[0],n[24],n[24],n[24],n[24],n[24],n[24] }},
                { 2, new Vector3[] {n[23],n[23],n[23],n[23],n[23],n[23],n[25],n[25],n[25],n[25],n[25],n[25],n[24],n[24],n[24],n[24],n[24],n[24] }},
                { 4, new Vector3[] {n[23],n[23],n[23],n[23],n[23],n[23],n[20],n[20],n[20],n[20],n[20],n[20],n[25],n[25],n[25],n[0],n[0],n[0],n[0],n[0],n[0],n[24],n[24],n[24],n[24],n[24],n[24] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8],n[0],n[0],n[0],n[0],n[0],n[0],n[26],n[26],n[26] }},
                { 3, new Vector3[] {n[8],n[8],n[8],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 4, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[26],n[26],n[26] }},
                { 0, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0],n[6],n[6],n[6] }},
                { 4, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 3, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0],n[6],n[6],n[6] }},
                { 2, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 3, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[6],n[6],n[6] }},
                { 1, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[6],n[6],n[6] }},
                { 2, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 5, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[9],n[9],n[9],n[9],n[9],n[9] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19] }},
                { 5, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[12],n[12],n[12] }},
                { 5, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[12],n[12],n[12] }},
                { 1, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 2, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[22],n[22],n[22],n[22],n[22],n[22] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 0, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 5, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[27],n[27],n[27] }},
                { 2, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[27],n[27],n[27] }},
                { 1, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 0, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 5, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[11],n[11],n[11] }},
                { 3, new Vector3[] {n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[28],n[28],n[28],n[28],n[28],n[28],n[9],n[9],n[9],n[1],n[1],n[1],n[29],n[29],n[29],n[29],n[29],n[29] }},
                { 3, new Vector3[] {n[28],n[28],n[28],n[28],n[28],n[28],n[30],n[30],n[30],n[30],n[30],n[30],n[29],n[29],n[29],n[29],n[29],n[29] }},
                { 5, new Vector3[] {n[28],n[28],n[28],n[28],n[28],n[28],n[9],n[9],n[9],n[9],n[9],n[9],n[30],n[30],n[30],n[1],n[1],n[1],n[1],n[1],n[1],n[29],n[29],n[29],n[29],n[29],n[29] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[31],n[31],n[31],n[31],n[31],n[31],n[3],n[3],n[3],n[0],n[0],n[0],n[32],n[32],n[32],n[32],n[32],n[32] }},
                { 5, new Vector3[] {n[31],n[31],n[31],n[31],n[31],n[31],n[33],n[33],n[33],n[33],n[33],n[33],n[32],n[32],n[32],n[32],n[32],n[32] }},
                { 3, new Vector3[] {n[31],n[31],n[31],n[31],n[31],n[31],n[3],n[3],n[3],n[3],n[3],n[3],n[33],n[33],n[33],n[0],n[0],n[0],n[0],n[0],n[0],n[32],n[32],n[32],n[32],n[32],n[32] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[10],n[10],n[10],n[1],n[1],n[1],n[1],n[1],n[1],n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 5, new Vector3[] {n[10],n[10],n[10],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 1, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }},
                { 0, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[7],n[7],n[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[24],n[24],n[24],n[24],n[24],n[24],n[1],n[1],n[1],n[22],n[22],n[22],n[23],n[23],n[23],n[23],n[23],n[23] }},
                { 3, new Vector3[] {n[24],n[24],n[24],n[24],n[24],n[24],n[34],n[34],n[34],n[34],n[34],n[34],n[23],n[23],n[23],n[23],n[23],n[23] }},
                { 5, new Vector3[] {n[24],n[24],n[24],n[24],n[24],n[24],n[1],n[1],n[1],n[1],n[1],n[1],n[34],n[34],n[34],n[22],n[22],n[22],n[22],n[22],n[22],n[23],n[23],n[23],n[23],n[23],n[23] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1],n[6],n[6],n[6] }},
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1],n[6],n[6],n[6] }},
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 3, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19],n[3],n[3],n[3],n[3],n[3],n[3],n[2],n[2],n[2] }},
                { 1, new Vector3[] {n[19],n[19],n[19],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 3, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[2],n[2],n[2] }},
                { 2, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 0, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[6],n[6],n[6] }},
                { 2, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[6],n[6],n[6] }},
                { 3, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 4, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[12],n[12],n[12] }},
                { 0, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[12],n[12],n[12] }},
                { 4, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[12],n[12],n[12] }},
                { 4, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[12],n[12],n[12] }},
                { 5, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }},
                { 0, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }},
                { 5, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }},
                { 4, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[36],n[36],n[36],n[36],n[36],n[36],n[22],n[22],n[22],n[1],n[1],n[1],n[37],n[37],n[37],n[37],n[37],n[37] }},
                { 4, new Vector3[] {n[36],n[36],n[36],n[36],n[36],n[36],n[38],n[38],n[38],n[38],n[38],n[38],n[37],n[37],n[37],n[37],n[37],n[37] }},
                { 2, new Vector3[] {n[36],n[36],n[36],n[36],n[36],n[36],n[22],n[22],n[22],n[22],n[22],n[22],n[38],n[38],n[38],n[1],n[1],n[1],n[1],n[1],n[1],n[37],n[37],n[37],n[37],n[37],n[37] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1],n[12],n[12],n[12] }},
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1],n[12],n[12],n[12] }},
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 4, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[39],n[39],n[39],n[1],n[1],n[1],n[1],n[1],n[1],n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 2, new Vector3[] {n[39],n[39],n[39],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 1, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }},
                { 5, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[35],n[35],n[35] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 5, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[12],n[12],n[12] }},
                { 0, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[12],n[12],n[12] }},
                { 4, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[37],n[37],n[37],n[37],n[37],n[37],n[0],n[0],n[0],n[20],n[20],n[20],n[36],n[36],n[36],n[36],n[36],n[36] }},
                { 5, new Vector3[] {n[37],n[37],n[37],n[37],n[37],n[37],n[40],n[40],n[40],n[40],n[40],n[40],n[36],n[36],n[36],n[36],n[36],n[36] }},
                { 3, new Vector3[] {n[37],n[37],n[37],n[37],n[37],n[37],n[0],n[0],n[0],n[0],n[0],n[0],n[40],n[40],n[40],n[20],n[20],n[20],n[20],n[20],n[20],n[36],n[36],n[36],n[36],n[36],n[36] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35],n[0],n[0],n[0],n[0],n[0],n[0],n[41],n[41],n[41] }},
                { 4, new Vector3[] {n[35],n[35],n[35],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 3, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[41],n[41],n[41] }},
                { 0, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0],n[12],n[12],n[12] }},
                { 4, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0],n[12],n[12],n[12] }},
                { 3, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 5, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 1, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[12],n[12],n[12] }},
                { 4, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[12],n[12],n[12] }},
                { 5, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2],n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 4, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2],n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 5, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2],n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 3, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2],n[42],n[42],n[42],n[42],n[42],n[42] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 3, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2] }},
                { 4, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2] }},
                { 2, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 5, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2] }},
                { 2, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2] }},
                { 4, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 1, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2] }},
                { 5, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2] }},
                { 2, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2] }},
                { 4, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[22],n[22],n[22] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[0],n[0],n[0] }},
                { 6, new Vector3[] {n[22],n[22],n[22] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 1, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[3],n[3],n[3],n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[43],n[43],n[43],n[43],n[43],n[43],n[11],n[11],n[11],n[3],n[3],n[3],n[44],n[44],n[44],n[44],n[44],n[44] }},
                { 0, new Vector3[] {n[43],n[43],n[43],n[43],n[43],n[43],n[45],n[45],n[45],n[45],n[45],n[45],n[44],n[44],n[44],n[44],n[44],n[44] }},
                { 6, new Vector3[] {n[43],n[43],n[43],n[43],n[43],n[43],n[11],n[11],n[11],n[11],n[11],n[11],n[45],n[45],n[45],n[3],n[3],n[3],n[3],n[3],n[3],n[44],n[44],n[44],n[44],n[44],n[44] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 6, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[47],n[47],n[47],n[47],n[47],n[47],n[4],n[4],n[4],n[1],n[1],n[1],n[48],n[48],n[48],n[48],n[48],n[48] }},
                { 6, new Vector3[] {n[47],n[47],n[47],n[47],n[47],n[47],n[49],n[49],n[49],n[49],n[49],n[49],n[48],n[48],n[48],n[48],n[48],n[48] }},
                { 0, new Vector3[] {n[47],n[47],n[47],n[47],n[47],n[47],n[4],n[4],n[4],n[4],n[4],n[4],n[49],n[49],n[49],n[1],n[1],n[1],n[1],n[1],n[1],n[48],n[48],n[48],n[48],n[48],n[48] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[27],n[27],n[27] }},
                { 6, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[27],n[27],n[27] }},
                { 2, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[8],n[8],n[8],n[1],n[1],n[1],n[1],n[1],n[1],n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 0, new Vector3[] {n[8],n[8],n[8],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 1, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }},
                { 2, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[46],n[46],n[46] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 3, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[20],n[20],n[20],n[20],n[20],n[20] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[29],n[29],n[29],n[29],n[29],n[29],n[3],n[3],n[3],n[20],n[20],n[20],n[28],n[28],n[28],n[28],n[28],n[28] }},
                { 0, new Vector3[] {n[29],n[29],n[29],n[29],n[29],n[29],n[50],n[50],n[50],n[50],n[50],n[50],n[28],n[28],n[28],n[28],n[28],n[28] }},
                { 6, new Vector3[] {n[29],n[29],n[29],n[29],n[29],n[29],n[3],n[3],n[3],n[3],n[3],n[3],n[50],n[50],n[50],n[20],n[20],n[20],n[20],n[20],n[20],n[28],n[28],n[28],n[28],n[28],n[28] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 1, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 6, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3],n[6],n[6],n[6] }},
                { 3, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3],n[6],n[6],n[6] }},
                { 6, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 0, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[51],n[51],n[51] }},
                { 3, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[51],n[51],n[51] }},
                { 2, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7],n[3],n[3],n[3],n[3],n[3],n[3],n[26],n[26],n[26] }},
                { 3, new Vector3[] {n[7],n[7],n[7],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 6, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[26],n[26],n[26] }},
                { 2, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 1, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 6, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 1, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[6],n[6],n[6] }},
                { 3, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[6],n[6],n[6] }},
                { 0, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 6, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[20],n[20],n[20],n[20],n[20],n[20] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[14],n[14],n[14],n[14],n[14],n[14],n[20],n[20],n[20],n[11],n[11],n[11],n[13],n[13],n[13],n[13],n[13],n[13] }},
                { 0, new Vector3[] {n[14],n[14],n[14],n[14],n[14],n[14],n[52],n[52],n[52],n[52],n[52],n[52],n[13],n[13],n[13],n[13],n[13],n[13] }},
                { 6, new Vector3[] {n[14],n[14],n[14],n[14],n[14],n[14],n[20],n[20],n[20],n[20],n[20],n[20],n[52],n[52],n[52],n[11],n[11],n[11],n[11],n[11],n[11],n[13],n[13],n[13],n[13],n[13],n[13] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 1, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 4, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11],n[12],n[12],n[12] }},
                { 6, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 4, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11],n[12],n[12],n[12] }},
                { 0, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[48],n[48],n[48],n[48],n[48],n[48],n[11],n[11],n[11],n[20],n[20],n[20],n[47],n[47],n[47],n[47],n[47],n[47] }},
                { 2, new Vector3[] {n[48],n[48],n[48],n[48],n[48],n[48],n[53],n[53],n[53],n[53],n[53],n[53],n[47],n[47],n[47],n[47],n[47],n[47] }},
                { 4, new Vector3[] {n[48],n[48],n[48],n[48],n[48],n[48],n[11],n[11],n[11],n[11],n[11],n[11],n[53],n[53],n[53],n[20],n[20],n[20],n[20],n[20],n[20],n[47],n[47],n[47],n[47],n[47],n[47] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19],n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 6, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19],n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 2, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19],n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 4, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19],n[26],n[26],n[26],n[26],n[26],n[26] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11],n[27],n[27],n[27] }},
                { 6, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11],n[27],n[27],n[27] }},
                { 4, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 2, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 2, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19] }},
                { 0, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19] }},
                { 6, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 1, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 3, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 6, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20],n[21],n[21],n[21] }},
                { 6, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 3, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20],n[21],n[21],n[21] }},
                { 0, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[9],n[9],n[9],n[9],n[9],n[9],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 3, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[9],n[9],n[9],n[9],n[9],n[9],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 4, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[22],n[22],n[22],n[22],n[22],n[22],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 1, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[22],n[22],n[22],n[22],n[22],n[22],n[4],n[4],n[4],n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 6, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[9],n[9],n[9],n[9],n[9],n[9],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 4, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 3, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20],n[51],n[51],n[51] }},
                { 4, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 6, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20],n[51],n[51],n[51] }},
                { 2, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 0, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 2, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 4, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 3, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 4, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[4],n[4],n[4],n[4],n[4],n[4],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 3, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 6, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 1, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 6, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 3, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }},
                { 5, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[54],n[54],n[54],n[54],n[54],n[54],n[1],n[1],n[1],n[9],n[9],n[9],n[55],n[55],n[55],n[55],n[55],n[55] }},
                { 6, new Vector3[] {n[54],n[54],n[54],n[54],n[54],n[54],n[56],n[56],n[56],n[56],n[56],n[56],n[55],n[55],n[55],n[55],n[55],n[55] }},
                { 0, new Vector3[] {n[54],n[54],n[54],n[54],n[54],n[54],n[1],n[1],n[1],n[1],n[1],n[1],n[56],n[56],n[56],n[9],n[9],n[9],n[9],n[9],n[9],n[55],n[55],n[55],n[55],n[55],n[55] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[27],n[27],n[27] }},
                { 1, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[27],n[27],n[27] }},
                { 5, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[2],n[2],n[2],n[2],n[2],n[2],n[11],n[11],n[11],n[11],n[11],n[11],n[5],n[5],n[5] }},
                { 1, new Vector3[] {n[2],n[2],n[2],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 6, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[5],n[5],n[5] }},
                { 5, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[27],n[27],n[27] }},
                { 5, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[27],n[27],n[27] }},
                { 6, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1],n[27],n[27],n[27] }},
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1],n[27],n[27],n[27] }},
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 6, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }},
                { 5, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }},
                { 2, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }},
                { 6, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 2, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[27],n[27],n[27] }},
                { 5, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[27],n[27],n[27] }},
                { 6, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[55],n[55],n[55],n[55],n[55],n[55],n[20],n[20],n[20],n[3],n[3],n[3],n[54],n[54],n[54],n[54],n[54],n[54] }},
                { 5, new Vector3[] {n[55],n[55],n[55],n[55],n[55],n[55],n[57],n[57],n[57],n[57],n[57],n[57],n[54],n[54],n[54],n[54],n[54],n[54] }},
                { 3, new Vector3[] {n[55],n[55],n[55],n[55],n[55],n[55],n[20],n[20],n[20],n[20],n[20],n[20],n[57],n[57],n[57],n[3],n[3],n[3],n[3],n[3],n[3],n[54],n[54],n[54],n[54],n[54],n[54] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5],n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 3, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5],n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 0, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5],n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 6, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5],n[41],n[41],n[41],n[41],n[41],n[41] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3],n[27],n[27],n[27] }},
                { 3, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 6, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3],n[27],n[27],n[27] }},
                { 5, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 0, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5] }},
                { 5, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5] }},
                { 3, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 1, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39],n[3],n[3],n[3],n[3],n[3],n[3],n[42],n[42],n[42] }},
                { 6, new Vector3[] {n[39],n[39],n[39],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 3, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[42],n[42],n[42] }},
                { 2, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 6, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5] }},
                { 3, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5] }},
                { 5, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 6, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[27],n[27],n[27] }},
                { 1, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[27],n[27],n[27] }},
                { 5, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5] }},
                { 0, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5] }},
                { 5, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5] }},
                { 3, new Vector3[] {n[5],n[5],n[5],n[5],n[5],n[5] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[58],n[58],n[58] }},
                { 6, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[58],n[58],n[58] }},
                { 5, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10],n[11],n[11],n[11],n[11],n[11],n[11],n[41],n[41],n[41] }},
                { 4, new Vector3[] {n[10],n[10],n[10],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 6, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[41],n[41],n[41] }},
                { 5, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 1, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 4, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 4, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[12],n[12],n[12] }},
                { 1, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[12],n[12],n[12] }},
                { 0, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46],n[11],n[11],n[11],n[11],n[11],n[11],n[42],n[42],n[42] }},
                { 6, new Vector3[] {n[46],n[46],n[46],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 4, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[42],n[42],n[42] }},
                { 5, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 4, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19] }},
                { 6, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19] }},
                { 0, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 1, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[27],n[27],n[27] }},
                { 6, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[27],n[27],n[27] }},
                { 2, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19] }},
                { 2, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19] }},
                { 0, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19] }},
                { 6, new Vector3[] {n[19],n[19],n[19],n[19],n[19],n[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20],n[58],n[58],n[58] }},
                { 3, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 4, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1],n[20],n[20],n[20],n[20],n[20],n[20],n[58],n[58],n[58] }},
                { 5, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 5, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 0, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 6, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 4, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 3, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[22],n[22],n[22],n[22],n[22],n[22],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 6, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 4, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 1, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 3, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 4, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 2, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 5, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 3, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 6, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 3, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 4, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 6, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 1, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 4, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 6, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 6, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }},
                { 3, new Vector3[] {n[1],n[1],n[1],n[1],n[1],n[1] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[20],n[20],n[20] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 0, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[9],n[9],n[9],n[9],n[9],n[9] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[1],n[1],n[1] }},
                { 7, new Vector3[] {n[20],n[20],n[20] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[44],n[44],n[44],n[44],n[44],n[44],n[4],n[4],n[4],n[9],n[9],n[9],n[43],n[43],n[43],n[43],n[43],n[43] }},
                { 1, new Vector3[] {n[44],n[44],n[44],n[44],n[44],n[44],n[59],n[59],n[59],n[59],n[59],n[59],n[43],n[43],n[43],n[43],n[43],n[43] }},
                { 7, new Vector3[] {n[44],n[44],n[44],n[44],n[44],n[44],n[4],n[4],n[4],n[4],n[4],n[4],n[59],n[59],n[59],n[9],n[9],n[9],n[9],n[9],n[9],n[43],n[43],n[43],n[43],n[43],n[43] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 2, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[4],n[4],n[4],n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 2, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 7, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[17],n[17],n[17],n[17],n[17],n[17],n[22],n[22],n[22],n[4],n[4],n[4],n[16],n[16],n[16],n[16],n[16],n[16] }},
                { 1, new Vector3[] {n[17],n[17],n[17],n[17],n[17],n[17],n[60],n[60],n[60],n[60],n[60],n[60],n[16],n[16],n[16],n[16],n[16],n[16] }},
                { 7, new Vector3[] {n[17],n[17],n[17],n[17],n[17],n[17],n[22],n[22],n[22],n[22],n[22],n[22],n[60],n[60],n[60],n[4],n[4],n[4],n[4],n[4],n[4],n[16],n[16],n[16],n[16],n[16],n[16] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4],n[6],n[6],n[6] }},
                { 0, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4],n[6],n[6],n[6] }},
                { 7, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 1, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 3, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[21],n[21],n[21] }},
                { 0, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[21],n[21],n[21] }},
                { 3, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[61],n[61],n[61],n[61],n[61],n[61],n[0],n[0],n[0],n[3],n[3],n[3],n[62],n[62],n[62],n[62],n[62],n[62] }},
                { 7, new Vector3[] {n[61],n[61],n[61],n[61],n[61],n[61],n[63],n[63],n[63],n[63],n[63],n[63],n[62],n[62],n[62],n[62],n[62],n[62] }},
                { 1, new Vector3[] {n[61],n[61],n[61],n[61],n[61],n[61],n[0],n[0],n[0],n[0],n[0],n[0],n[63],n[63],n[63],n[3],n[3],n[3],n[3],n[3],n[3],n[62],n[62],n[62],n[62],n[62],n[62] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[10],n[10],n[10],n[4],n[4],n[4],n[4],n[4],n[4],n[2],n[2],n[2],n[2],n[2],n[2] }},
                { 3, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }},
                { 7, new Vector3[] {n[10],n[10],n[10],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 0, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[2],n[2],n[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[51],n[51],n[51] }},
                { 7, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[51],n[51],n[51] }},
                { 3, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 0, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 2, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[46],n[46],n[46],n[4],n[4],n[4],n[4],n[4],n[4],n[5],n[5],n[5],n[5],n[5],n[5] }},
                { 7, new Vector3[] {n[46],n[46],n[46],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 3, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 2, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[5],n[5],n[5] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 2, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[6],n[6],n[6] }},
                { 0, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[6],n[6],n[6] }},
                { 1, new Vector3[] {n[6],n[6],n[6],n[6],n[6],n[6] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 4, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[21],n[21],n[21] }},
                { 7, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[21],n[21],n[21] }},
                { 4, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[64],n[64],n[64],n[64],n[64],n[64],n[11],n[11],n[11],n[0],n[0],n[0],n[65],n[65],n[65],n[65],n[65],n[65] }},
                { 7, new Vector3[] {n[64],n[64],n[64],n[64],n[64],n[64],n[66],n[66],n[66],n[66],n[66],n[66],n[65],n[65],n[65],n[65],n[65],n[65] }},
                { 1, new Vector3[] {n[64],n[64],n[64],n[64],n[64],n[64],n[11],n[11],n[11],n[11],n[11],n[11],n[66],n[66],n[66],n[0],n[0],n[0],n[0],n[0],n[0],n[65],n[65],n[65],n[65],n[65],n[65] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[7],n[7],n[7],n[9],n[9],n[9],n[9],n[9],n[9],n[2],n[2],n[2],n[2],n[2],n[2] }},
                { 7, new Vector3[] {n[7],n[7],n[7],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 4, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 0, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[2],n[2],n[2] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[65],n[65],n[65],n[65],n[65],n[65],n[4],n[4],n[4],n[22],n[22],n[22],n[64],n[64],n[64],n[64],n[64],n[64] }},
                { 4, new Vector3[] {n[65],n[65],n[65],n[65],n[65],n[65],n[67],n[67],n[67],n[67],n[67],n[67],n[64],n[64],n[64],n[64],n[64],n[64] }},
                { 2, new Vector3[] {n[65],n[65],n[65],n[65],n[65],n[65],n[4],n[4],n[4],n[4],n[4],n[4],n[67],n[67],n[67],n[22],n[22],n[22],n[22],n[22],n[22],n[64],n[64],n[64],n[64],n[64],n[64] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4],n[21],n[21],n[21] }},
                { 7, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4],n[21],n[21],n[21] }},
                { 2, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 4, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39],n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 4, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39],n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 2, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39],n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 7, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39],n[7],n[7],n[7],n[7],n[7],n[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 4, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 1, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 7, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 0, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[21],n[21],n[21] }},
                { 3, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[21],n[21],n[21] }},
                { 7, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }},
                { 3, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }},
                { 4, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }},
                { 7, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0],n[21],n[21],n[21] }},
                { 1, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 4, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0],n[21],n[21],n[21] }},
                { 7, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 4, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[21],n[21],n[21] }},
                { 3, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[21],n[21],n[21] }},
                { 7, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[42],n[42],n[42],n[4],n[4],n[4],n[4],n[4],n[4],n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 3, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 2, new Vector3[] {n[42],n[42],n[42],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 7, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[41],n[41],n[41] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 0, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[21],n[21],n[21] }},
                { 7, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[21],n[21],n[21] }},
                { 4, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 2, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 7, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 1, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 3, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 4, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 1, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7] }},
                { 7, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 5, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[22],n[22],n[22],n[22],n[22],n[22] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 0, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 7, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[32],n[32],n[32],n[32],n[32],n[32],n[9],n[9],n[9],n[22],n[22],n[22],n[31],n[31],n[31],n[31],n[31],n[31] }},
                { 1, new Vector3[] {n[32],n[32],n[32],n[32],n[32],n[32],n[68],n[68],n[68],n[68],n[68],n[68],n[31],n[31],n[31],n[31],n[31],n[31] }},
                { 7, new Vector3[] {n[32],n[32],n[32],n[32],n[32],n[32],n[9],n[9],n[9],n[9],n[9],n[9],n[68],n[68],n[68],n[22],n[22],n[22],n[22],n[22],n[22],n[31],n[31],n[31],n[31],n[31],n[31] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9],n[12],n[12],n[12] }},
                { 5, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9],n[12],n[12],n[12] }},
                { 7, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 1, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 5, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 7, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[3],n[3],n[3],n[3],n[3],n[3],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[11],n[11],n[11],n[11],n[11],n[11],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[3],n[3],n[3],n[3],n[3],n[3],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 7, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[11],n[11],n[11],n[11],n[11],n[11],n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22],n[27],n[27],n[27] }},
                { 2, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22],n[27],n[27],n[27] }},
                { 7, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 1, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 7, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[3],n[3],n[3],n[3],n[3],n[3],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 2, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 5, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[62],n[62],n[62],n[62],n[62],n[62],n[22],n[22],n[22],n[9],n[9],n[9],n[61],n[61],n[61],n[61],n[61],n[61] }},
                { 3, new Vector3[] {n[62],n[62],n[62],n[62],n[62],n[62],n[69],n[69],n[69],n[69],n[69],n[69],n[61],n[61],n[61],n[61],n[61],n[61] }},
                { 5, new Vector3[] {n[62],n[62],n[62],n[62],n[62],n[62],n[22],n[22],n[22],n[22],n[22],n[22],n[69],n[69],n[69],n[9],n[9],n[9],n[9],n[9],n[9],n[61],n[61],n[61],n[61],n[61],n[61] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9],n[21],n[21],n[21] }},
                { 5, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 7, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9],n[21],n[21],n[21] }},
                { 3, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10],n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 3, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10],n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 5, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10],n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 7, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10],n[46],n[46],n[46],n[46],n[46],n[46] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 1, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }},
                { 3, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }},
                { 5, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 0, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22],n[51],n[51],n[51] }},
                { 7, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22],n[51],n[51],n[51] }},
                { 5, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 3, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[0],n[0],n[0],n[0],n[0],n[0],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 7, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[3],n[3],n[3],n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 3, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 1, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 7, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 2, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 2, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 7, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 0, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[58],n[58],n[58] }},
                { 5, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[58],n[58],n[58] }},
                { 4, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 5, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 0, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9],n[9] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[39],n[39],n[39],n[9],n[9],n[9],n[9],n[9],n[9],n[19],n[19],n[19],n[19],n[19],n[19] }},
                { 4, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }},
                { 7, new Vector3[] {n[39],n[39],n[39],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 5, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[19],n[19],n[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 0, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[12],n[12],n[12] }},
                { 5, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[12],n[12],n[12] }},
                { 1, new Vector3[] {n[12],n[12],n[12],n[12],n[12],n[12] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22],n[58],n[58],n[58] }},
                { 2, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 7, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0],n[22],n[22],n[22],n[22],n[22],n[22],n[58],n[58],n[58] }},
                { 4, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[11],n[11],n[11],n[11],n[11],n[11],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 7, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 1, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }},
                { 4, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }},
                { 2, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 5, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 0, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 7, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 5, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35],n[20],n[20],n[20],n[20],n[20],n[20],n[10],n[10],n[10] }},
                { 4, new Vector3[] {n[35],n[35],n[35],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 3, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[10],n[10],n[10] }},
                { 7, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 7, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[21],n[21],n[21] }},
                { 0, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[21],n[21],n[21] }},
                { 3, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 7, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }},
                { 5, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }},
                { 3, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 4, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }},
                { 7, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }},
                { 5, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }},
                { 3, new Vector3[] {n[10],n[10],n[10],n[10],n[10],n[10] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 4, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 3, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 5, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 7, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 7, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 4, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 3, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 5, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 2, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 7, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 7, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }},
                { 5, new Vector3[] {n[0],n[0],n[0],n[0],n[0],n[0] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 6, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[70],n[70],n[70],n[70],n[70],n[70],n[9],n[9],n[9],n[4],n[4],n[4],n[71],n[71],n[71],n[71],n[71],n[71] }},
                { 6, new Vector3[] {n[70],n[70],n[70],n[70],n[70],n[70],n[72],n[72],n[72],n[72],n[72],n[72],n[71],n[71],n[71],n[71],n[71],n[71] }},
                { 0, new Vector3[] {n[70],n[70],n[70],n[70],n[70],n[70],n[9],n[9],n[9],n[9],n[9],n[9],n[72],n[72],n[72],n[4],n[4],n[4],n[4],n[4],n[4],n[71],n[71],n[71],n[71],n[71],n[71] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[71],n[71],n[71],n[71],n[71],n[71],n[3],n[3],n[3],n[11],n[11],n[11],n[70],n[70],n[70],n[70],n[70],n[70] }},
                { 7, new Vector3[] {n[71],n[71],n[71],n[71],n[71],n[71],n[73],n[73],n[73],n[73],n[73],n[73],n[70],n[70],n[70],n[70],n[70],n[70] }},
                { 1, new Vector3[] {n[71],n[71],n[71],n[71],n[71],n[71],n[3],n[3],n[3],n[3],n[3],n[3],n[73],n[73],n[73],n[11],n[11],n[11],n[11],n[11],n[11],n[70],n[70],n[70],n[70],n[70],n[70] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8],n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 6, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8],n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 0, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8],n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 7, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8],n[35],n[35],n[35],n[35],n[35],n[35] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[51],n[51],n[51] }},
                { 2, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[51],n[51],n[51] }},
                { 6, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4],n[51],n[51],n[51] }},
                { 0, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 7, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[4],n[4],n[4],n[4],n[4],n[4],n[51],n[51],n[51] }},
                { 6, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[8],n[8],n[8],n[22],n[22],n[22],n[22],n[22],n[22],n[5],n[5],n[5],n[5],n[5],n[5] }},
                { 6, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }},
                { 7, new Vector3[] {n[8],n[8],n[8],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 2, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[5],n[5],n[5] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 1, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }},
                { 6, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }},
                { 0, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 2, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[51],n[51],n[51] }},
                { 6, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[51],n[51],n[51] }},
                { 7, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[7],n[7],n[7],n[7],n[7],n[7],n[20],n[20],n[20],n[20],n[20],n[20],n[8],n[8],n[8] }},
                { 3, new Vector3[] {n[7],n[7],n[7],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 6, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[8],n[8],n[8] }},
                { 7, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3],n[51],n[51],n[51] }},
                { 1, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 3, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[3],n[3],n[3],n[3],n[3],n[3],n[51],n[51],n[51] }},
                { 7, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 7, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }},
                { 0, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }},
                { 6, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 3, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }},
                { 6, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }},
                { 3, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }},
                { 7, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 7, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[51],n[51],n[51] }},
                { 2, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[51],n[51],n[51] }},
                { 6, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 3, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[51],n[51],n[51] }},
                { 6, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[51],n[51],n[51] }},
                { 7, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }},
                { 7, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }},
                { 0, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }},
                { 6, new Vector3[] {n[8],n[8],n[8],n[8],n[8],n[8] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[58],n[58],n[58] }},
                { 4, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[58],n[58],n[58] }},
                { 7, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[26],n[26],n[26],n[9],n[9],n[9],n[9],n[9],n[9],n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 4, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 0, new Vector3[] {n[26],n[26],n[26],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 7, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[42],n[42],n[42] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11],n[58],n[58],n[58] }},
                { 1, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 6, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[11],n[11],n[11],n[11],n[11],n[11],n[58],n[58],n[58] }},
                { 7, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 0, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 7, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 1, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 4, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46],n[20],n[20],n[20],n[20],n[20],n[20],n[39],n[39],n[39] }},
                { 6, new Vector3[] {n[46],n[46],n[46],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 4, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[39],n[39],n[39] }},
                { 7, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 6, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 4, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 2, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 7, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 7, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }},
                { 2, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }},
                { 4, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 6, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 6, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 4, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 2, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 0, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 7, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 4, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 3, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20],n[20] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 6, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 3, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[21],n[21],n[21] }},
                { 4, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[21],n[21],n[21] }},
                { 0, new Vector3[] {n[21],n[21],n[21],n[21],n[21],n[21] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 1, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[9],n[9],n[9],n[9],n[9],n[9],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 4, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 6, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[4],n[4],n[4],n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 3, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 6, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 4, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 4, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 6, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[51],n[51],n[51] }},
                { 3, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[51],n[51],n[51] }},
                { 2, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 6, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 4, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 2, new Vector3[] {n[26],n[26],n[26],n[26],n[26],n[26] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 6, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 4, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 3, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 6, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }},
                { 4, new Vector3[] {n[4],n[4],n[4],n[4],n[4],n[4] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[58],n[58],n[58] }},
                { 7, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[58],n[58],n[58] }},
                { 6, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9],n[58],n[58],n[58] }},
                { 7, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9],n[58],n[58],n[58] }},
                { 0, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 6, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[35],n[35],n[35],n[22],n[22],n[22],n[22],n[22],n[22],n[19],n[19],n[19],n[19],n[19],n[19] }},
                { 7, new Vector3[] {n[35],n[35],n[35],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 6, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 5, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[19],n[19],n[19] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 6, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 1, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 7, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 5, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 2, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 5, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22],n[22] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[3],n[3],n[3],n[3],n[3],n[3],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 7, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[11],n[11],n[11],n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 7, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 5, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[27],n[27],n[27] }},
                { 2, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[27],n[27],n[27] }},
                { 1, new Vector3[] {n[27],n[27],n[27],n[27],n[27],n[27] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 5, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 7, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 2, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[41],n[41],n[41],n[22],n[22],n[22],n[22],n[22],n[22],n[26],n[26],n[26],n[26],n[26],n[26] }},
                { 6, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 5, new Vector3[] {n[41],n[41],n[41],n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 7, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[26],n[26],n[26] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 3, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 6, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 0, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 7, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 5, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 7, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 1, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 6, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 3, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 6, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 0, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 5, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 7, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 2, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[51],n[51],n[51] }},
                { 7, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[51],n[51],n[51] }},
                { 3, new Vector3[] {n[51],n[51],n[51],n[51],n[51],n[51] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 7, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 3, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 1, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46] }},
                { 7, new Vector3[] {n[46],n[46],n[46],n[46],n[46],n[46] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 7, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }},
                { 0, new Vector3[] {n[3],n[3],n[3],n[3],n[3],n[3] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }},
                { 4, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }},
                { 6, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }},
                { 7, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 5, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[58],n[58],n[58] }},
                { 7, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9],n[58],n[58],n[58] }},
                { 6, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 6, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[58],n[58],n[58] }},
                { 4, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11],n[58],n[58],n[58] }},
                { 7, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 6, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 1, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35] }},
                { 7, new Vector3[] {n[35],n[35],n[35],n[35],n[35],n[35] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 7, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[58],n[58],n[58] }},
                { 5, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[58],n[58],n[58] }},
                { 4, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 7, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }},
                { 7, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }},
                { 2, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }},
                { 4, new Vector3[] {n[39],n[39],n[39],n[39],n[39],n[39] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 7, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }},
                { 2, new Vector3[] {n[11],n[11],n[11],n[11],n[11],n[11] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 3, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 4, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[58],n[58],n[58] }},
                { 6, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20],n[58],n[58],n[58] }},
                { 5, new Vector3[] {n[58],n[58],n[58],n[58],n[58],n[58] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 5, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 3, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 6, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }},
                { 0, new Vector3[] {n[41],n[41],n[41],n[41],n[41],n[41] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 4, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 3, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22],n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 6, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 3, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }},
                { 6, new Vector3[] {n[9],n[9],n[9],n[9],n[9],n[9] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 2, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 4, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 3, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }},
                { 5, new Vector3[] {n[42],n[42],n[42],n[42],n[42],n[42] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 0, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 2, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }},
                { 5, new Vector3[] {n[20],n[20],n[20],n[20],n[20],n[20] }}
            },
            new Dictionary<int, Vector3[]>()
            {
                { 1, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 4, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }},
                { 3, new Vector3[] {n[22],n[22],n[22],n[22],n[22],n[22] }}
            },
            new Dictionary<int, Vector3[]>()
    };

    private static int GetIndex(bool[] input)
    {
        int index = 0;
        index = input[0] ? (index | 1) : index;
        index = input[1] ? (index | 2) : index;
        index = input[2] ? (index | 4) : index;
        index = input[3] ? (index | 8) : index;
        index = input[4] ? (index | 16) : index;
        index = input[5] ? (index | 32) : index;
        index = input[6] ? (index | 64) : index;
        index = input[7] ? (index | 128) : index;
        return index;
    }
    public static Dictionary<int, Vector3[]> GetIndexToVertices(bool[] input)
    {
        int index = GetIndex(input);
        return vertexTable[index];
    }
    public static Dictionary<int, Vector3[]> GetIndexToNormals(bool[] input)
    {
        int index = GetIndex(input);
        return normalTable[index];
    }
}

