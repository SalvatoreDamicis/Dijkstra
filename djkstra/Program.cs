// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MinimumSpanningTree;

public class Program
{   
    static int[,] get_matrix_distance(int n_nodes)
    {
        Random rnd = new Random();
        int[,] distance = new int[n_nodes, n_nodes];
        
        for (int j = 0; j < n_nodes; j++)
            {
                for (int i = j; i < n_nodes; i++)
                {
                    distance[i, j] = rnd.Next(0,10);
                    distance[j, i] = distance[i, j];
                    distance[i, i] = 0;
                }
            }
        return distance;
    }

    static void print_matrix_distance(int[,] matrix)
    {   
        int shapeRows = matrix.GetLength(0); 
        int shapeColumns = matrix.GetLength(1);
        for (int i = 0; i < shapeRows ; i++)
            {
                for (int j = 0; j < shapeColumns; j++)
                {
                    Console.Write(matrix[i,j] + "\t");
                }
            Console.WriteLine("\n");
            }
    }


    public void Main()
    {   
        int NUMBER_NODES = 10;
        int[,] distance_matrix = Program.get_matrix_distance(NUMBER_NODES);
        
        Program.print_matrix_distance(distance_matrix);

        MinimumSpanningTree.Dijstra search_alg = new MinimumSpanningTree.Dijstra();
        int[] prev_node = search_alg.dijstra(distance_matrix, 5);
        search_alg.print_mst(prev_node);
    }
}    