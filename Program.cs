using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NguyenPhanBaoNgoc
{
    internal class Program
    {
        class TaskItem
        {
            // Ten viec can lam
            public string Name { get; set; }
            // Do uu tien
            public int Priority { get; set; }
            // Mo ta
            public string Description { get; set; }
            // Trang thai
            public string Status { get; set; }
            public TaskItem(string name, int priority, string description)
            {
                Name = name;
                Priority = priority;
                Description = description;
                Status = "Chua hoan thanh";
            }
        }
        class TaskManager
        {
            private List<TaskItem> tasks = new List<TaskItem>();
            public void ShowTasks()
            {
                if (tasks.Count == 0)
                {
                    Console.WriteLine($"[{tasks.Count}]");
                    Console.WriteLine("Chua co cong viec nao duoc ghi nhan!");
                }
                else
                {
                    Console.WriteLine($"[{tasks.Count}]");
                    foreach (var task in tasks)
                    {
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine($"+++ Vi tri trong danh sach: {tasks.IndexOf(task)}");
                        Console.WriteLine("Ten: "+task.Name);
                        Console.WriteLine("Do uu tien: "+task.Priority);
                        Console.WriteLine("Mo ta: "+task.Description);
                        Console.WriteLine("Trang thai: "+task.Status);
                    }
                }

            }
            public void AddTask()
            {
                Console.WriteLine("Nhap ten cong viec: ");
                string name = Console.ReadLine();
                Console.WriteLine("Nhap do uu tien (tu 1 den 5): ");
                int priority = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nhap mo ta cong viec: ");
                string description = Console.ReadLine();
                TaskItem task = new TaskItem(name, priority, description);
                tasks.Add(task);
                Console.WriteLine("Them thanh cong!!!");
            }
            public int DeleteTask(int index)
            {
                Console.WriteLine("Da xoa cong viec: "+tasks[index].Name);
                tasks.Remove(tasks[index]);
                return 1;
            }
            public string EditTask(string name)
            {
                TaskItem taskToEdit = tasks.FirstOrDefault(k => k.Name == name);
                if (taskToEdit != null)
                {
                    Console.WriteLine("Ten cong viec: "+name);
                    Console.WriteLine("Nhap trang thai moi: ");
                    string newStatus = Console.ReadLine();
                    taskToEdit.Status = newStatus;
                    Console.WriteLine("Cap nhat thanh cong!!!");
                    return "Cap nhat thanh cong!!!";
                }
                else
                {
                    Console.WriteLine("Khong tim thay cong viec!");
                }
                    return "Khong tim thay cong viec!";
            }
            public string SearchTaskName(string text)
            {
                TaskItem tasktoSearch = tasks.FirstOrDefault(k => k.Name == text);
                if (tasktoSearch != null) { 
                    foreach (var task in tasks)
                    {
                        if (task.Name == text)
                        {
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine($"+++ Vi tri trong danh sach: {tasks.IndexOf(task)}");
                            Console.WriteLine("Ten: " + task.Name);
                            Console.WriteLine("Do uu tien: " + task.Priority);
                            Console.WriteLine("Mo ta: " + task.Description);
                            Console.WriteLine("Trang thai: " + task.Status);
                        }
                    }
                    return "Tim kiem thanh cong!";
                }
                return "Khong tim thay ten cong viec theo yeu cau!";
            }
            public string SearchTaskPriority(int number)
            {
                TaskItem tasktoSearch = tasks.FirstOrDefault(k => k.Priority == number);
                if (tasktoSearch != null)
                {
                    foreach (var task in tasks)
                    {
                        if (task.Priority == number)
                        {
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine($"+++ Vi tri trong danh sach: {tasks.IndexOf(task)}");
                            Console.WriteLine("Ten: " + task.Name);
                            Console.WriteLine("Do uu tien: " + task.Priority);
                            Console.WriteLine("Mo ta: " + task.Description);
                            Console.WriteLine("Trang thai: " + task.Status);
                        }
                    }
                    return "Tim kiem thanh cong!";
                }
                return "Khong tim thay do uu tien theo yeu cau!";
            }
            public void SortTask()
            {
                // Sap xep giam dan theo do uu tien
                tasks.Sort((a,b)=>b.Priority.CompareTo(a.Priority));
                for (int i= 0; i<tasks.Count; i++)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Ten: " + tasks[i].Name);
                    Console.WriteLine("Do uu tien: " + tasks[i].Priority);
                    Console.WriteLine("Mo ta: " + tasks[i].Description);
                    Console.WriteLine("Trang thai: " + tasks[i].Status);
                }
            }
        };
        static void Main(string[] args)
        {
            //TaskItem task = new TaskItem("Hoc bai Sinh hoc", 2, "Hoc trang 25");
            //Console.WriteLine(task.Name+"\t"+task.Priority);
            //Console.ReadLine();
            TaskManager manager = new TaskManager();
            while (true)
            {

                Console.WriteLine("PHAN MEM QUAN LY GHI CHU CONG VIEC");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1. Them mot cong viec");
                Console.WriteLine("2. Xem danh sach cong viec can lam");
                Console.WriteLine("3. Xoa thong tin cong viec");
                Console.WriteLine("4. Cap nhat trang thai cong viec");
                Console.WriteLine("5. Tim kiem cong viec theo ten/do uu tien");
                Console.WriteLine("6. Danh sach cong viec giam dan theo do uu tien");
                Console.WriteLine("7. Ket thuc quan ly");
                Console.Write("Nhap so tuong ung de thuc hien hanh dong tiep theo: ");
                int x = Convert.ToInt32(Console.ReadLine());
                while (x >= 1 && x <= 7)
                {
                    switch (x)
                    {
                        case 1:
                            {
                                manager.AddTask();
                                break;
                            }
                        case 2:
                            {

                                Console.WriteLine("Cac cong viec hien co: ");
                                manager.ShowTasks();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Nhap vi tri cong viec can xoa: ");
                                int key = Convert.ToInt32(Console.ReadLine());
                                manager.DeleteTask(key);
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Nhap ten cong viec: ");
                                string name = Console.ReadLine();
                                manager.EditTask(name);
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Nhap ten cong viec hoac do uu tien (1 den 5): ");
                                string text = Console.ReadLine();
                                // Kiem tra text xem co the chuyen doi thanh so nguyen khong
                                if (int.TryParse(text, out int num))
                                {
                                    // Thanh cong thi tim kiem theo ham do uu tien
                                    manager.SearchTaskPriority(num);
                                }
                                else
                                {
                                    // Khong thanh cong thi tim kiem theo ten
                                    manager.SearchTaskName(text);
                                }
                                break;
                            }
                        case 6:
                            {
                                manager.SortTask();
                                break;
                            }
                        case 7:
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Lua chon khong hop le. Vui long chon lai!");
                                break;
                            }
                    }
                    break;

                }
                continue;
            }
        }
    }
}
