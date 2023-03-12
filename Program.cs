using System;
using static System.Console;

WriteLine("Задача №54: ");
WriteLine();

int[,] GetArray (int rows, int columns, int minValue, int maxValue){
    int[,] array = new int[rows, columns];
    for(int i = 0; i < rows; i++){
        for(int j = 0; j < columns; j++){
            array[i,j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return array;
}

void PrintArray (int[,] array){
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            Write($"{array[i,j]} ");
        }
        WriteLine();
    }
}

int[,] SortArray (int[,] array) {
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            for(int k = j + 1; k < array.GetLength(1); k++){
                if(array[i,j] < array[i,k]){
                    int tmp = array[i,j];
                    array[i,j] = array[i,k];
                    array[i,k] = tmp;
                }
            }
        }
    }
    return array;
}


Write("Введите количество строк в массиве: ");
int rows = int.Parse(ReadLine()!);

Write("Введите количество столбцов в массиве: ");
int columns = int.Parse(ReadLine()!);

Write("Введите минимальное значение массива: ");
int minValue = int.Parse(ReadLine()!);

Write("Введите максимальное значение элементов: ");
int maxValue = int.Parse(ReadLine()!);

int[,] array = GetArray(rows, columns, minValue, maxValue);
WriteLine("Изначальный двумерный массив: ");
PrintArray(array);
WriteLine();
int[,] sortedArray = SortArray(array);
WriteLine("Сортированный по убыванию двумерный массив: ");
PrintArray(sortedArray);

WriteLine();
WriteLine("Задача №56");

int[] Sum (int[,] array){
    int sum = 0;
    int[] sums = new int[array.GetLength(0)];
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            sum += array[i,j];
        }
        sums[i] = sum;
        sum = 0;
    }
    return sums;
}

void PrintOneArray (int[] array){
    foreach(int el in array){
        Write($"{el} ");
    }
}

int MinSum (int[] array) {
    int minSum = array[0];
    for(int i = 0; i < array.Length; i++){
        if(minSum > array[i]){
            minSum = array[i];
        }
    }
    return minSum;
}

Write("Введите количество строк в массиве: ");
rows = int.Parse(ReadLine()!);

Write("Введите количество столбцов в массиве: ");
columns = int.Parse(ReadLine()!);

Write("Введите минимальное значение массива: ");
minValue = int.Parse(ReadLine()!);

Write("Введите максимальное значение элементов: ");
maxValue = int.Parse(ReadLine()!);

int[,] table = GetArray(rows, columns, minValue, maxValue);
WriteLine("Изначальный массив: ");
PrintArray(table);
WriteLine();
int[] strokesSum = Sum(table);
Write("Сумма каждой строки: ");
PrintOneArray(strokesSum);
WriteLine();
int minSum = MinSum(strokesSum);
Write("Минимальная сумма строки: ");
WriteLine(minSum);

WriteLine();
WriteLine("Задача №58");

int[,] MatrixMultiply (int[,] m1, int[,] m2){
    int[,] result = new int[m1.GetLength(0), m1.GetLength(1)];
    for(int i = 0; i < result.GetLength(1); i++){
        for(int j = 0; j < result.GetLength(0); j++){
            int sum = 0;
            sum +=  m1[i, j] * m2[i, j];
            result[i,j] = sum;
        }
    }
    return result;
}


int[,] matrix1 = GetArray (2,2, 1,9);
WriteLine("Матрица №1");
PrintArray(matrix1);
int[,] matrix2 = GetArray (2,2,1,9);
WriteLine("Матрица №2");
PrintArray(matrix2);
int[,] matrix3 = MatrixMultiply (matrix1, matrix2);
WriteLine("Прозведение матриц");
PrintArray(matrix3);


WriteLine();
WriteLine("Задача №60");

string[,,] GetCubeArray (int x, int y, int z, int minValue, int maxValue) {
    string[,,] array = new string[x, y, z];
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            for(int k = 0; k < array.GetLength(2); k++){
                array[i, j, k] = new Random().Next(minValue, maxValue + 1).ToString();
            }
        }
    }
    return array;
}

void PrintCubeArray (string[,,] array){
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            for(int k = 0; k < array.GetLength(2); k++){
                Write($"{array[i,j,k]} ");
            }
            WriteLine();
        }
        WriteLine();
    }
}

void AddIndex (string[,,] array) {
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            for(int k = 0; k < array.GetLength(2); k++){
                Write($"{array[i, j, k]} index: ({i}, {j}, {k}); ");
            }
            WriteLine();
        }
        WriteLine();
    } 
}

Write("Введите длину в массиве: ");
int x = int.Parse(ReadLine()!);

Write("Введите ширину в массиве: ");
int y = int.Parse(ReadLine()!);

Write("Введите глубину в массиве: ");
int z = int.Parse(ReadLine()!);

Write("Введите минимальное значение массива: ");
minValue = int.Parse(ReadLine()!);

Write("Введите максимальное значение элементов: ");
maxValue = int.Parse(ReadLine()!);

string[,,] cube = GetCubeArray (x, y, z, minValue, maxValue);
PrintCubeArray(cube);
WriteLine();
AddIndex(cube);

WriteLine();
WriteLine("Задача №62");
WriteLine();

string Zero (string element) {
    if (Convert.ToInt32(element) > 0 && Convert.ToInt32(element) < 10){
        return "0" + element;
    }else {
        return element;
    }
}

string[,] FillArray (string[,] matrix, int line, int size, int element) {
    while(size > 2){
        for (int i = line; i < size; i++){
            matrix[line, i] = Zero(element.ToString());
            element += 1;
        }
        for (int i = line + 1; i < size; i++){
            matrix[i, size - 1] = Zero(element.ToString());
            element += 1;
        }   
        for (int i = size - 2; i + 1 > line; i--){
            matrix[size - 1, i] = Zero(element.ToString());
            element += 1;
        }
        for (int i = size - 2; i > line; i--){
            matrix[i, line] = Zero(element.ToString());
            element += 1;
        }
        size -= 1;
        line += 1;
    }
    return matrix;
}

void PrintStrArray (string[,] array){
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            Write($"{array[i,j]} ");
        }
        WriteLine();
    }
}

Write("Введите размер матрицы: ");
int size = int.Parse(ReadLine()!);

string[,] matrix = new string[size,size];

int element = 1;

int line = 0;

matrix = FillArray(matrix, line, size, element);

PrintStrArray(matrix);



