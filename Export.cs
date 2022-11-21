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
                    sw.WriteLine(node?.Info ?? "Null");

                    if (node?.IsTail ?? true)
                    {
                        return;
                    }
                        
                    node = node?.next ?? new DoublyNode("null", false, false);
                    totalLines++;
                }
            }
        }
    }
}
