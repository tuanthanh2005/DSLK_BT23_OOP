using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bt1_LienKetCauTruc
{
    class Node
    {
        private float info;
        private Node next;



        public Node(float x)
        {
            info = x;
            next = null;
        }
        public float InFo
        {
            set { info = value; }
            get { return info; }
        }
        public Node Next
        {
            set { next = value; }
            get { return next; }
        }


        class DSLienKetDon
        {
            private Node Head;

            public DSLienKetDon()
            {
                Head = null;
            }
            public void ThemDau(float x)
            {
                Node q = new Node(x);

                q.Next = Head;
                Head = q;
            }
            public void XoaDau()
            {
                if (Head != null)
                {
                    Node p = Head;
                    Head = Head.next;
                    p.next = null;
                }
            }

            public Node TimMax()
            {
                Node max = Head;
                Node p = null;
                while (p != null)
                {
                    if (p.info > max.info)



                        max = p;
                    p = p.next;
                }
                return max;
            }
            public float AVG()
            {
                float sum = 0;
                int count = 0;
                Node p = Head;
                while (p != null)
                {
                    sum = sum + p.info;
                    count++;
                    p = p.next;
                }
                return sum / count;
            }






            public void Xuat()
            {
                Node p = Head;
                while (p != null)
                {
                    Console.WriteLine($"{p.info}\t");
                    p = p.Next;
                }
            }

            public void XoabatKi(float x)
            {
                Node p = Head;
                Node q = null;


                while (p != null && p.info != x)
                {
                    q = p;
                    p = p.next;
                }
                if (p != null)
                {
                    if (p == Head)
                        XoaDau();

                    else
                    {
                        q.next = p.next;
                        p.next = null;
                    }

                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                DSLienKetDon ds = new DSLienKetDon();
                NhapDanhSach(ds);
                Console.WriteLine("Danh Sach Lien Ket");
                ds.Xuat();
                ds.XoaDau();
                Console.WriteLine("Sau Khi Xoa Dau");
                ds.Xuat();
                Console.WriteLine();

                Console.Write("Nhap Gia Tri Xoa :");
                float x = float.Parse(Console.ReadLine());
                ds.XoabatKi(x);
                Console.WriteLine("Danh Sach Lien Ket Sau Khi Xoa 1 Nut");
                ds.Xuat();
                Console.WriteLine($"Node Co Gia tri max {ds.TimMax().info}");
                Console.WriteLine($"Gia tri Trung Binh La {ds.AVG()}");
                Console.ReadLine();
            }

            static void NhapDanhSach(DSLienKetDon l)
            {
                string chon = "y";
                float x;
                while (chon != "n")
                {
                    Console.Write("Nhap Gia tri Node :");
                    x = float.Parse(Console.ReadLine());
                    l.ThemDau(x);
                    Console.Write("tiep Tuc Nhap (y/n)");
                    chon = Console.ReadLine();
                }


            }
        }
    }
}
