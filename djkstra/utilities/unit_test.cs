using System;
public class UnitTest
{   
    static void TestDijkstra()
    {   
        int START = 0;
        int[,] distance_matrix = {
            {0,1,4,4,2}, 
            {1,0,3,int.MaxValue,int.MaxValue}, 
            {4,3,0,3,1}, 
            {4,int.MaxValue,3,0,1}, 
            {2,int.MaxValue,1,1,0}
        }; 

        MinimumSpanningTree.Dijstra search_alg = new MinimumSpanningTree.Dijstra();
        int[] prev_node = search_alg.dijstra(distance_matrix, START);  

        int[] expected_solution = {0,0,4,4,0};

        for (int i=0; i < 5; i++)
        {   
            if (prev_node[i] != expected_solution[i])
            {   
                Console.WriteLine("Test Failed!!"); 
                System.Environment.Exit(0); 
            }
        }
        Console.WriteLine("Test Passed!!"); 

    }
    static void Main()
    {   
        Console.WriteLine("Init test");
        UnitTest.TestDijkstra();
        
    }

}