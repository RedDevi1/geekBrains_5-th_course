var matrixSize = 5;
var matrix = new int[matrixSize, matrixSize];
var cnt = 0;
var indent = 0;
while (cnt < 26)
{
    for (var i = 0; i < matrixSize; i++)
    {
        indent++;
        if (i == 0 && cnt == 0)
        {
            for (var j = 0; j < matrixSize; j++)
            {
                cnt++;
                matrix[i, j] = cnt;
            }
        }
        else if (i > 0 && i < matrixSize - 1)
        {
            cnt++;
            matrix[i, matrixSize - indent] = cnt;
        }
        else if (i == matrixSize - 1 && cnt < 15)
        {
            for (var j = matrixSize - 1; j >= 0; j--)
            {
                cnt++;
                matrix[i, j] = cnt;
            }
        }
    }
}

