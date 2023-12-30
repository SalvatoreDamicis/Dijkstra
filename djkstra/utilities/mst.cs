using System.Reflection.Metadata.Ecma335;

namespace MinimumSpanningTree;

class Dijstra 
{
    public int[] dijstra(int[,] adjacent_matrix, int depot)
    /* this function returns array with the previous nodes. 
    (for example [i] is the previuos node of i,  
    the edge [i]->i is an edge of minimum spanning tree) */
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
                if ( (distance_measure[i] > distance_measure[next_node] + adjacent_matrix[next_node, i]) 
                    & 
                    (adjacent_matrix[next_node, i] != int.MaxValue))
                {   
                    distance_measure[i] = distance_measure[next_node] + adjacent_matrix[next_node, i];
                    previous_nodes[i] = next_node;
                }
            }

            unvisited_nodes.Remove(next_node);
        }
    
            return previous_nodes;
    }
    static int nearest_node(int[] distance_measure, List<int> unvisited_nodes)
    // returns the node not jet visited with minor distance from the source  
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
   
    public void print_mst(int[] array)
    // print minimun spanning tree
    {
        int len_array = array.GetLength(0);
        for (int i=0; i<len_array; i++)
        {
            Console.Write($"{array[i]} -> {i} \n");
        }
        Console.WriteLine();
    }

}