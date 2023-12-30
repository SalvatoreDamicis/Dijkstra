using System.Reflection.Metadata.Ecma335;

namespace MinimumSpanningTree;

class Dijstra 
{
    public void dijstra(int[,] adjacent_matrix, int depot)
    {   
        int number_nodes = adjacent_matrix.GetLength(0);
        List<int> unvisited_nodes = Enumerable.Range(0, number_nodes).ToList();

        int[] previous_nodes = new int[number_nodes];
        int[] distance_measure = new int[number_nodes];
        for (int i = 0; i < number_nodes; i++)
        {
            distance_measure[i] = int.MaxValue;
            previous_nodes[i] = i;
        }
        distance_measure[depot] = 0;
        
        while (unvisited_nodes.Count != 0)
        {   
            int next_node = nearest_node(distance_measure, unvisited_nodes);
            
            for (int i=0; i < number_nodes; i++)
            {
                if (distance_measure[i] > distance_measure[next_node] + adjacent_matrix[next_node, i])
                {   
                    distance_measure[i] = distance_measure[next_node] + adjacent_matrix[next_node, i];
                    previous_nodes[i] = next_node;
                }
            }

            

            Console.WriteLine(next_node);
            unvisited_nodes.Remove(next_node);
        }
    
    static int nearest_node(int[] distance_measure, List<int> unvisited_nodes)
    {
        int len_distance_measure = distance_measure.GetLength(0);
        int node_min_value = len_distance_measure;

        int min_value = int.MaxValue;
        for (int i=0; i < len_distance_measure; i++)
        {
            if ((min_value > distance_measure[i]) & (unvisited_nodes.Contains(i)))
            {   
                node_min_value = i;
                min_value = distance_measure[i];
            }
        }

    return node_min_value;
    }
   
    
        print_array(previous_nodes);
    }

    static void print_array(int[] array)
    {
        int len_array = array.GetLength(0);
        for (int i=0; i<len_array; i++)
        {
            Console.Write($"{array[i]} ");
        }
        Console.WriteLine();
    }

    static private int[] get_distance_array(int len, int depot)
    {
        int[] dis_arr = new int[len];
        for (int i = 0; i < len; i++)
                {
                    dis_arr[i] = int.MaxValue;
                }
        dis_arr[depot] = 0;
        return dis_arr;
    }
}