var matrixSize = 5;
var matrix = new int[matrixSize, matrixSize];
var cnt = 1;
var indent = 0;
while (cnt < matrixSize * matrixSize)
{
    for (var i = indent; i < matrixSize - indent; i++)
    {
        matrix[indent, i] = cnt;
        cnt++;
    }

    for (var i = indent + 1; i < matrixSize - indent; i++)
    {
        matrix[i, matrixSize - 1 - indent] = cnt;
        cnt++;
    }

    for (var i = matrixSize - 2 - indent; i >= indent; i--)
    {
        matrix[matrixSize - 1 - indent, i] = cnt;
        cnt++;
    }

    for (var i = matrixSize - 2 - indent; i > indent; i--)
    {
        matrix[i, indent] = cnt;
        cnt++;
    }

    indent++;
}

matrix[indent, indent] = cnt;

for (var i = 0; i < matrixSize; i++)
{
    for (var j = 0; j < matrixSize; j++)
    {
        Console.Write("{0} ", matrix[i, j]);
    }
    Console.WriteLine();
}

