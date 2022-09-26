using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InClass9_19.Constants;

namespace InClass9_19
{
    internal class Export
    {
        public static void RunExport(DoublyNode node)
        {
            int maxLines = 10;
            int totalLines = 0;
            using (StreamWriter sw = new StreamWriter(writePath, false))
            {
                while (totalLines < maxLines)
                {
                    // I tested it and this null check is not needed as far as my testing revealed but I opted to leave it in for extra assurance
                    // Removed single line ifs in favor of bracketed ifs
                    if (node == null)
                    {
                        return;
                    }
                        
                    sw.WriteLine(node.Info);

                    if (node.IsTail)
                    {
                        return;
                    }
                        
                    node = node.next;
                    totalLines++;
                }
            }
        }
    }
}
