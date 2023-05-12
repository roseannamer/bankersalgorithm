using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OSassignment
{
    public partial class Form2 : Form
    {
        private int numResources;
        private int numProcesses;
        private int[] totalResources;
        private int resourceAmount;
        private int[,] maximumNeed;
        private int[,] currentAllocation;
        private int[] availableResources;
        private DataTable dtTotalResources;
        private DataTable dtAvailableResources;
        private DataTable dtCurrentlyAllocated;
        private DataTable dtMaximumNeed;
        private DataTable dtRemainingNeed;
        private TextBox txtResourceName;
        private TextBox txtResourceTotal;
        private TextBox txtResourceAvailable;
        private TextBox txtProcessName;
        private TextBox txtProcessNum;
        private TextBox txtResourceNum;
        private TextBox txtResourceAmount;
        private TextBox txtNumProcesses;
        private TextBox txtNumResources;


        public Form2(int numResources, int numProcesses)
        {
            InitializeComponent();
            this.numResources = numResources;
            this.numProcesses = numProcesses;
            availableResources = new int[numResources];

            TextBox txtNumResources = new TextBox();
            TextBox txtNumProcesses = new TextBox();
            TextBox txtProcessName = new TextBox();
            TextBox txtResourceName = new TextBox();
            TextBox txtResourceAmount = new TextBox();


            txtNumResources.Text = "";
            txtNumProcesses.Text = "";
            txtProcessName.Text = "";
            txtResourceName.Text = "";
            txtResourceAmount.Text = "";


            // Initialize the DataTable for the total resources
            dtTotalResources = new DataTable();
            dtTotalResources.Columns.Add("Resource");
            for (int i = 1; i <= numResources; i++)
            {
                dtTotalResources.Columns.Add("R" + i.ToString());
            }

            // Add rows for each resource
            for (int i = 1; i <= numResources; i++)
            {
                DataRow newRow = dtTotalResources.NewRow();
                newRow["Resource"] = "R" + i.ToString();
                for (int j = 1; j <= numProcesses; j++)
                {
                    newRow["R" + i.ToString()] = "0";
                }
                dtTotalResources.Rows.Add(newRow);
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dtTotalResources;



            // Initialize the DataTable for the available resources
            dtAvailableResources = new DataTable();
            dtAvailableResources.Columns.Add("Resource");
            for (int i = 1; i <= numResources; i++)
            {
                dtAvailableResources.Columns.Add("R" + i.ToString());
            }

            // Add rows for each resource
            for (int i = 1; i <= numResources; i++)
            {
                DataRow newRow = dtAvailableResources.NewRow();
                newRow["Resource"] = "R" + i.ToString();
                for (int j = 1; j <= numProcesses; j++)
                {
                    newRow["R" + i.ToString()] = "0";
                }
                dtAvailableResources.Rows.Add(newRow);
            }

            // Bind the DataTable to the DataGridView
            dataGridView2.DataSource = dtAvailableResources;

            // Initialize the DataTable for the currently allocated processes
            DataTable dtCurrentlyAllocated = new DataTable();
            dtCurrentlyAllocated.Columns.Add("Process");
            for (int i = 1; i <= numResources; i++)
            {
                dtCurrentlyAllocated.Columns.Add("R" + i.ToString());
            }

            // Add rows for each process
            for (int i = 1; i <= numProcesses; i++)
            {
                DataRow newRow = dtCurrentlyAllocated.NewRow();
                newRow["Process"] = "P" + i.ToString();
                for (int j = 1; j <= numResources; j++)
                {
                    newRow["R" + j.ToString()] = "0";
                }
                dtCurrentlyAllocated.Rows.Add(newRow);
            }

            // Bind the DataTable to the DataGridView
            dataGridView3.DataSource = dtCurrentlyAllocated;

            // Initialize the DataTable for the maximum need
            DataTable dtMaximumNeed = new DataTable();
            dtMaximumNeed.Columns.Add("Process");
            for (int i = 1; i <= numResources; i++)
            {
                dtMaximumNeed.Columns.Add("R" + i.ToString());
            }

            // Add rows for each process
            for (int i = 1; i <= numProcesses; i++)
            {
                DataRow newRow = dtMaximumNeed.NewRow();
                newRow["Process"] = "P" + i.ToString();
                for (int j = 1; j <= numResources; j++)
                {
                    newRow["R" + j.ToString()] = "0";
                }
                dtMaximumNeed.Rows.Add(newRow);
            }

            // Bind the DataTable to the DataGridView
            dataGridView4.DataSource = dtMaximumNeed;

            // Initialize the DataTable for the remaining need
            DataTable dtRemainingNeed = new DataTable();
            dtRemainingNeed.Columns.Add("Process");
            for (int i = 1; i <= numResources; i++)
            {
                dtRemainingNeed.Columns.Add("R" + i.ToString());
            }

            // Add rows for each process
            for (int i = 1; i <= numProcesses; i++)
            {
                DataRow newRow = dtRemainingNeed.NewRow();
                newRow["Process"] = "P" + i.ToString();
                for (int j = 1; j <= numResources; j++)
                {
                    newRow["R" + j.ToString()] = "0";
                }
                dtRemainingNeed.Rows.Add(newRow);
            }

            // Bind the DataTable to the DataGridView
            dataGridView5.DataSource = dtRemainingNeed;

            // Initialize the DataTable for the request
            DataTable dtRequest = new DataTable();
            dtRequest.Columns.Add("Process");
            for (int i = 1; i <= numResources; i++)
            {
                dtRequest.Columns.Add("R" + i.ToString());
            }
            dtRequest.Columns.Add("Action");

            // Add rows for each process
            for (int i = 1; i <= numProcesses; i++)
            {
                DataRow newRow = dtRequest.NewRow();
                newRow["Process"] = "P" + i.ToString();
                for (int j = 1; j <= numResources; j++)
                {
                    newRow["R" + j.ToString()] = "0";
                }
                newRow["Action"] = "Request";
                dtRequest.Rows.Add(newRow);
            }

            // Set the DataSource of the DataGridView to the DataTable
            dataGridView6.DataSource = dtRequest;



        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the resource name and total from the text boxes
            //string resourceName = txtResourceName.Text;
            int resourceTotal;
            if (int.TryParse(txtResourceTotal.Text, out resourceTotal))
            {
                // Add the resource to the DataTable
                DataRow newRow = dtTotalResources.NewRow();
                //newRow["Resource"] = resourceName;
                for (int i = 1; i <= numProcesses; i++)
                {
                    newRow["R" + i.ToString()] = resourceTotal.ToString();
                }
                dtTotalResources.Rows.Add(newRow);

                // Clear the text boxes
                txtResourceName.Text = "";
                txtResourceTotal.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the resource total.");
            }
        }

        private void UpdateAvailableResources(int[] requestedResources)
        {
            for (int i = 0; i < numResources; i++)
            {
                availableResources[i] -= requestedResources[i];
            }
            dataGridView2.DataSource = availableResources;
        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string resourceName = txtResourceName.Text;
            int resourceAvailable;
            if (int.TryParse(txtResourceAvailable.Text, out resourceAvailable))
            {
                // Add the resource to the DataTable
                DataRow newRow = dtAvailableResources.NewRow();
                //newRow["Resource"] = resourceName;
                for (int i = 1; i <= numProcesses; i++)
                {
                    newRow["R" + i.ToString()] = resourceAvailable.ToString();
                }
                dtAvailableResources.Rows.Add(newRow);

                // Clear the text boxes
                txtResourceName.Text = "";
                txtResourceTotal.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the resource total.");
            }


            /* bool isValidInput = true;

             for (int i = 0; i < numResources; i++)
             {
                 int.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString(), out availableResources[i]);

                 if (availableResources[i] < 0)
                 {
                     isValidInput = false;
                     break;
                 }
             }

             if (isValidInput)
             {
                 // Do something with availableResources, such as pass it to the banker's algorithm.
                 this.Close();
             }
             else
             {
                 MessageBox.Show("Please enter valid non-negative integer values for available resources.");
             } */





            /* int[] availableResources = new int[numResources];
             Console.WriteLine("Enter the available resources vector:");
             string[] availableInput = Console.ReadLine().Split(' ');
             for (int i = 0; i < numResources; i++)
             {
                 availableResources[i] = int.Parse(availableInput[i]);
             } */

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string resourceName = txtResourceName.Text;
            DataRow newRow = dtCurrentlyAllocated.NewRow();
            //newRow["Resource"] = resourceName;
            for (int i = 1; i <= numProcesses; i++)
            {
                int allocation;
                if (int.TryParse(dataGridView3.Rows[i - 1].Cells[1].Value.ToString(), out allocation))
                {
                    newRow["P" + i.ToString()] = allocation;
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for process " + i.ToString() + ".");
                    return;
                }
            }
            dtCurrentlyAllocated.Rows.Add(newRow);

            // Clear the text boxes and data grid view cells
            txtResourceName.Text = "";
            for (int i = 0; i < numProcesses; i++)
            {
                dataGridView3.Rows[i].Cells[1].Value = "";
            }

            /*  string resourceName = txtResourceName.Text;
              string processName = txtProcessName.Text;
              int currentlyAllocated;
              if (int.TryParse(txtResourceAvailable.Text, out currentlyAllocated))
              {
                  // Add the resource to the DataTable
                  DataRow newRow = dtCurrentlyAllocated.NewRow();
                  newRow["Resource"] = resourceName;
                  for (int i = 1; i <= numProcesses; i++)
                  {
                      newRow["R" + i.ToString()] = currentlyAllocated.ToString();
                  }
                  dtCurrentlyAllocated.Rows.Add(newRow);

                  // Clear the text boxes
                  txtResourceName.Text = "";
                  txtResourceTotal.Text = "";
              }
              else
              {
                  MessageBox.Show("Please enter a valid number for the resource total.");
              } */

            /* int[,] currentAllocation = new int[numProcesses, numResources];
             Console.WriteLine("Enter the current allocation matrix:");
             for (int i = 0; i < numProcesses; i++)
             {
                 Console.Write("Process " + i + ": ");
                 string[] input = Console.ReadLine().Split(' ');
                 for (int j = 0; j < numResources; j++)
                 {
                     currentAllocation[i, j] = int.Parse(input[j]);
                 }
             } */
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string resourceName = txtResourceName.Text;
            DataRow newRow = dtRemainingNeed.NewRow();
            newRow["Resource"] = resourceName;
            for (int i = 1; i <= numProcesses; i++)
            {
                int allocation;
                if (int.TryParse(dataGridView5.Rows[i - 1].Cells[1].Value.ToString(), out allocation))
                {
                    newRow["P" + i.ToString()] = allocation;
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for process " + i.ToString() + ".");
                    return;
                }
            }
            dtRemainingNeed.Rows.Add(newRow);

            // Clear the text boxes and data grid view cells
            txtResourceName.Text = "";
            for (int i = 0; i < numProcesses; i++)
            {
                dataGridView5.Rows[i].Cells[1].Value = "";
            }
            /*int[,] need = new int[numProcesses, numResources];
            for (int i = 0; i < numProcesses; i++)
            {
                for (int j = 0; j < numResources; j++)
                {
                    need[i, j] = maximumNeed[i, j] - currentAllocation[i, j];
                }
            } */
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string resourceName = txtResourceName.Text;
            DataRow newRow = dtMaximumNeed.NewRow();
            newRow["Resource"] = resourceName;
            for (int i = 1; i <= numProcesses; i++)
            {
                int allocation;
                if (int.TryParse(dataGridView4.Rows[i - 1].Cells[1].Value.ToString(), out allocation))
                {
                    newRow["P" + i.ToString()] = allocation;
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for process " + i.ToString() + ".");
                    return;
                }
            }
            dtMaximumNeed.Rows.Add(newRow);

            // Clear the text boxes and data grid view cells
            txtResourceName.Text = "";
            for (int i = 0; i < numProcesses; i++)
            {
                dataGridView4.Rows[i].Cells[1].Value = "";
            }

            /*  int[,] maximumNeed = new int[numProcesses, numResources];
              Console.WriteLine("Enter the maximum need matrix:");
              for (int i = 0; i < numProcesses; i++)
              {
                  Console.Write("Process " + i + ": ");
                  string[] input = Console.ReadLine().Split(' ');
                  for (int j = 0; j < numResources; j++)
                  {
                      maximumNeed[i, j] = int.Parse(input[j]);
                  }
              } */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] request = new int[m]; // array to hold the requested resources
            int process = -1; // variable to hold the index of the requesting process (-1 if no process is requesting)

            // check if a process is requesting resources
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Convert.ToInt32(dataGridView6.Rows[i].Cells[j + 1].Value) > 0)
                    {
                        request[j] = Convert.ToInt32(dataGridView6.Rows[i].Cells[j + 1].Value);
                        process = i;
                        break;
                    }
                }
                if (process != -1)
                {
                    break;
                }
            }

            if (process == -1) // no process is requesting resources
            {
                // check if the current state is safe
                bool[] finish = new bool[n]; // array to mark finished processes
                for (int i = 0; i < n; i++)
                {
                    finish[i] = false;
                }
                if (requestIsSafe(new int[m], -1, availbleResources, finish))
                {
                    MessageBox.Show("The system is in a safe state.", "Safe state");
                }
                else
                {
                    MessageBox.Show("The system is in an unsafe state.", "Unsafe state");
                }
            }
            else // a process is requesting resources
            {
                if (isSafe(request, process)) // the request can be granted
                {
                    MessageBox.Show("The request can be granted.", "Grant request");
                }
                else // the request cannot be granted
                {
                    MessageBox.Show("The request cannot be granted.", "Deny request");
                }
            }

        }


        private int n; // number of processes
        private int m; // number of resources

       // private int[,] maximumNeed; // maximum demand of each process
        private int[,] cuurentAllocation; // amount currently allocated to each process
        private int[,] need; // remaining need of each process
        private int[] availbleResources; // available resources
        private string i;

        // private int[] totalResources; //total resources

        // method to initialize the values of max, alloc, need, and avail arrays based on the DataGridView inputs
        private void initializeValues()
        {
            n = dataGridView3.Rows.Count - 1; // exclude the header row
            m = dataGridView3.Columns.Count - 1; // exclude the leftmost column

            // initialize the arrays
            maximumNeed = new int[n, m];
            cuurentAllocation = new int[n, m];
            need = new int[n, m];
            availbleResources = new int[m];

            // read values from DataGridViews and store them in the arrays
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    maximumNeed[i, j] = Convert.ToInt32(dataGridView4.Rows[i].Cells[j + 1].Value);
                    cuurentAllocation[i, j] = Convert.ToInt32(dataGridView4.Rows[i].Cells[j + 1].Value);
                    need[i, j] = maximumNeed[i, j] - cuurentAllocation[i, j];
                }
            }

            for (int j = 0; j < m; j++)
            {
                availbleResources[j] = Convert.ToInt32(dataGridView2.Rows[0].Cells[j + 1].Value);
            }
        }

            // method to check if the system is in a safe state
            private bool isSafe(int[] request, int process)
            {
                int[] work = new int[m]; // copy of available resources
                bool[] finish = new bool[n]; // array to mark finished processes

                // initialize work array and finish array
                for (int i = 0; i < m; i++)
                {
                    work[i] = availbleResources[i] - request[i];
                }
                for (int i = 0; i < n; i++)
                {
                    finish[i] = false;
                }

            // check if the request can be granted
           
            Console.WriteLine("Index: " + i + ", Length: " + finish.Length);

            if (requestIsSafe(request, process, work, finish))
                {
                    // simulate granting the request to see if the resulting state is still safe
                    for (int i = 0; i < m; i++)
                    {
                    availbleResources[i] -= request[i];
                    cuurentAllocation[process, i] += request[i];
                        need[process, i] -= request[i];
                    }

                    if (requestIsSafe(new int[m], -1, availbleResources, finish)) // check if the resulting state is safe
                    {
                        return true; // the request can be granted
                    }
                    else // the request cannot be granted
                    {
                        // undo the changes made to the arrays
                        for (int i = 0; i < m; i++)
                        {
                        availbleResources[i] += request[i];
                        cuurentAllocation[process, i] -= request[i];
                            need[process, i] += request[i];
                        }
                    }
                }

                return false; // the request cannot be granted
            }

            // helper method to check if a request can be granted
            private bool requestIsSafe(int[] request, int process, int[] work, bool[] finish)
            {
                int[] tempWork = new int[m]; // copy of work array
                bool[] tempFinish = new bool[n]; // copy of finish array
                for (int i = 0; i < m; i++)
                {
                    tempWork[i] = work[i];
                }
                for (int i = 0; i < n; i++)
                {
                    tempFinish[i] = finish[i];
                }
                // simulate allocating the requested resources to the process
                for (int i = 0; i < m; i++)
                {
                    tempWork[i] += request[i];
                }
                tempFinish[process] = true;

                // loop through all processes until all are finished or no process can be executed
                bool canExecute = true;
                while (canExecute)
                {
                    canExecute = false;
                    for (int i = 0; i < n; i++)
                    {
                        if (!tempFinish[i])
                        {
                            bool canBeAllocated = true;
                            for (int j = 0; j < m; j++)
                            {
                                if (tempWork[j] < need[i, j])
                                {
                                    canBeAllocated = false;
                                    break;
                                }
                            }
                            if (canBeAllocated)
                            {
                                for (int j = 0; j < m; j++)
                                {
                                    tempWork[j] += currentAllocation[i, j];
                                }
                                tempFinish[i] = true;
                                canExecute = true;
                            }
                        }
                    }
                }

                // check if all processes are finished
                for (int i = 0; i < n; i++)
                {
                    if (!tempFinish[i])
                    {
                        return false; // the request cannot be granted
                    }
                }

                return true; // the request can be granted
            }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Add columns to DataGridView
            DataGridViewTextBoxColumn colProcess = new DataGridViewTextBoxColumn();
            colProcess.HeaderText = "Process";
            colProcess.ReadOnly = true;
            colProcess.Width = 60;

            for (int i = 0; i < m; i++)
            {
                DataGridViewTextBoxColumn colResource = new DataGridViewTextBoxColumn();
                colResource.HeaderText = "Resource " + (i + 1).ToString();
                colResource.Width = 60;
                dataGridView6.Columns.Add(colResource);
            }

            dataGridView6.Columns.Add(colProcess);

            // Add rows to DataGridView
            for (int i = 0; i < n; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView6);
                for (int j = 0; j < m; j++)
                {
                    row.Cells[j].Value = "0";
                }
                row.Cells[m].Value = "P" + (i + 1).ToString();
                dataGridView6.Rows.Add(row);
            }

            // Set last column read-only
            dataGridView6.Columns[m].ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get request from DataGridView
            int processIndex = dataGridView6.CurrentCell.RowIndex;
            int[] request = new int[m];
            for (int i = 0; i < m; i++)
            {
                request[i] = Convert.ToInt32(dataGridView6.Rows[processIndex].Cells[i].Value);
            }

            // Check if request can be granted
            if (isSafe(request, processIndex))
            {
                // Grant the request
                for (int i = 0; i < m; i++)
                {
                    availbleResources[i] -= request[i];
                    cuurentAllocation[processIndex, i] += request[i];
                    need[processIndex, i] -= request[i];
                }

                // Update DataGridViews
                UpdateDataGridView(dataGridView1 , totalResources);
                UpdateDataGridView(dataGridView2, availbleResources);
                UpdateDataGridView(dataGridView3 , cuurentAllocation);
                UpdateDataGridView(dataGridView4, maximumNeed);
            }
            else
            {
                MessageBox.Show("The request cannot be granted.", "Banker's Algorithm");
            }
        }

        private void UpdateDataGridView(DataGridView dataGridView3, int[,] alloc)
        {
            throw new NotImplementedException();
        }

        private void UpdateDataGridView(DataGridView dataGridView1, int[] total)
        {
            throw new NotImplementedException();
        }
    }


    }




            /*  // Check if all required input values are provided
              if (txtNumResources != null && string.IsNullOrEmpty(txtNumResources.Text) ||
                  txtNumProcesses != null && string.IsNullOrEmpty(txtNumProcesses.Text) ||
                  txtResourceName != null && string.IsNullOrEmpty(txtResourceName.Text) ||
                  txtProcessName != null && string.IsNullOrEmpty(txtProcessName.Text) ||
                  txtResourceAmount != null && string.IsNullOrEmpty(txtResourceAmount.Text))
              {
                  MessageBox.Show("Please provide all required input values.");
                  return;
              }
              else
              {
                  // Parse input values
                  int numResources, numProcesses;
                  if (int.TryParse(txtNumResources.Text, out numResources) ||
                     int.TryParse(txtNumProcesses.Text, out numProcesses))
                  {
                      MessageBox.Show("Invalid input values for number of resources or processes.");
                      return;
                  }

                  int[] totalResources = new int[numResources];
                  int[] availableResources = new int[numResources];
                  int[,] currentAllocation = new int[numProcesses, numResources];
                  int[,] maximumNeed = new int[numProcesses, numResources];
                  int[,] remainingNeed = new int[numProcesses, numResources];
                  for (int i = 0; i < numResources; i++)
                  {
                      if (!int.TryParse(dataGridView1.Rows[i].Cells[1].Value?.ToString(), out totalResources[i]) ||
                          !int.TryParse(dataGridView2.Rows[i].Cells[1].Value?.ToString(), out availableResources[i]))
                      {
                          MessageBox.Show("Invalid input values for total or available resources.");
                          return;
                      }
                  }
                  for (int i = 0; i < numProcesses; i++)
                  {
                      for (int j = 0; j < numResources; j++)
                      {
                          if (!int.TryParse(dataGridView3.Rows[i].Cells[j + 1].Value?.ToString(), out currentAllocation[i, j]) ||
                              !int.TryParse(dataGridView4.Rows[i].Cells[j + 1].Value?.ToString(), out maximumNeed[i, j]))
                          {
                              MessageBox.Show("Invalid input values for currently allocated or maximum need.");
                              return;
                          }
                          remainingNeed[i, j] = maximumNeed[i, j] - currentAllocation[i, j];
                      }
                  }
                  int processIndex, resourceIndex, requestAmount;
                  if (!int.TryParse(txtProcessName.Text, out processIndex) ||
                      !int.TryParse(txtResourceName.Text, out resourceIndex) ||
                      !int.TryParse(txtResourceAmount.Text, out requestAmount))
                  {
                      MessageBox.Show("Invalid input values for process index, resource index, or request amount.");
                      return;
                  }
                  processIndex--;
                  resourceIndex--;

                  // Check if the request can be granted
                  bool[] canGrant = new bool[numProcesses];
                  for (int i = 0; i < numProcesses; i++)
                  {
                      canGrant[i] = true;
                      for (int j = 0; j < numResources; j++)
                      {
                          if (remainingNeed[i, j] < requestAmount || availableResources[j] < requestAmount)
                          {
                              canGrant[i] = false;
                              break;
                          }
                      }
                  }

                  // Allocate resources if the request can be granted
                  if (canGrant[processIndex])
                  {
                      for (int i = 0; i < numResources; i++)
                      {
                          availableResources[i] -= requestAmount;
                          currentAllocation[processIndex, i] = currentAllocation[processIndex, i] + requestAmount;
                          remainingNeed[processIndex, i] -= requestAmount;
                      }
                      // Check if the system is still in a safe state
                      bool[] isFinished = new bool[numProcesses];
                      int[] work = new int[numResources];
                      for (int i = 0; i < numResources; i++)
                      {
                          work[i] = availableResources[i];
                      }
                      while (true)
                      {
                          bool canFinish = false;
                          for (int i = 0; i < numProcesses; i++)
                          {
                              if (!isFinished[i])
                              {
                                  bool canRun = true;
                                  for (int j = 0; j < numResources; j++)
                                  {
                                      if (remainingNeed[i, j] > work[j])
                                      {
                                          canRun = false;
                                          break;
                                      }
                                  }
                                  if (canRun)
                                  {
                                      canFinish = true;
                                      isFinished[i] = true;
                                      for (int j = 0; j < numResources; j++)
                                      {
                                          work[j] += currentAllocation[i, j];
                                      }
                                  }
                              }
                          }
                          if (!canFinish)
                          {
                              bool isSafe = true;
                              for (int i = 0; i < numProcesses; i++)
                              {
                                  if (!isFinished[i])
                                  {
                                      isSafe = false;
                                      break;
                                  }
                              }
                              if (isSafe)
                              {
                                  MessageBox.Show("The request can be granted and the system is still in a safe state.");
                              }
                              else
                              {
                                  // Undo resource allocation
                                  for (int i = 0; i < numResources; i++)
                                  {
                                      availableResources[i] += requestAmount;
                                      currentAllocation[processIndex, i] -= requestAmount;
                                      remainingNeed[processIndex, i] += requestAmount;
                                  }
                                  MessageBox.Show("The request cannot be granted as the system will be in an unsafe state.");
                              }
                              break;
                          }
                      }
                  }
                  else
                  {
                      MessageBox.Show("The request cannot be granted as it may lead to an unsafe state.");
                  }
              } */










        
    

  


       


                /* // Prompt user to input number of processes and resources
                Console.Write("Enter number of processes: ");
                int numProcesses = int.Parse(Console.ReadLine()?? "0");
                Console.Write("Enter number of resources: ");
                int numResources = int.Parse(Console.ReadLine()"0");

                // Initialize arrays for resources
                int[] totalResources = new int[numResources];
                int[] availableResources = new int[numResources];
                int[,] currentAllocation = new int[numProcesses, numResources];
                int[,] maximumNeed = new int[numProcesses, numResources];

                // Prompt user to input total resources
                Console.WriteLine("Enter total resources:");
                for (int i = 0; i < numResources; i++)
                {
                    Console.Write("Resource " + (i + 1) + ": ");
                    totalResources[i] = int.Parse(Console.ReadLine());
                }

                // Prompt user to input available resources
                Console.WriteLine("Enter available resources:");
                for (int i = 0; i < numResources; i++)
                {
                    Console.Write("Resource " + (i + 1) + ": ");
                    availableResources[i] = int.Parse(Console.ReadLine());
                }

                // Prompt user to input current allocation
                Console.WriteLine("Enter current allocation:");
                for (int i = 0; i < numProcesses; i++)
                {
                    Console.Write("Process " + (i + 1) + ": ");
                    string[] currentAllocationValues = Console.ReadLine().Split(' ');
                    for (int j = 0; j < numResources; j++)
                    {
                        currentAllocation[i, j] = int.Parse(currentAllocationValues[j]);
                    }
                }

                // Prompt user to input maximum need
                Console.WriteLine("Enter maximum need:");
                for (int i = 0; i < numProcesses; i++)
                {
                    Console.Write("Process " + (i + 1) + ": ");
                    string[] maximumNeedValues = Console.ReadLine().Split(' ');
                    for (int j = 0; j < numResources; j++)
                    {
                        maximumNeed[i, j] = int.Parse(maximumNeedValues[j]);
                    }
                }

                // Prompt user to input resource request for a process
                Console.Write("Enter process number to request resource: ");
                int processNum = int.Parse(Console.ReadLine());
                Console.Write("Enter resource number to request: ");
                int resourceNum = int.Parse(Console.ReadLine());
                Console.Write("Enter resource request amount: ");
                int resourceAmount = int.Parse(Console.ReadLine());


            }

            // Banker's Algorithm for deadlock prevention
            static bool IsSafeState(int numProcesses, int numResources, int[] totalResources, int[] availableResources, int[,] currentAllocation, int[,]maximumNeed, int processNum, int resourceNum, int resourceAmount)
            {
                // Initialize work and finish arrays
                int[] work = new int[numResources];
                bool[] finish = new bool[numProcesses];
                // Initialize work array with available resources
                for (int i = 0; i < numResources; i++)
                {
                    work[i] = availableResources[i];
                }

                // Initialize finish array to false for all processes
                for (int i = 0; i < numProcesses; i++)
                {
                    finish[i] = false;
                }

                // Find a process that can be finished and satisfies resource request
                bool foundProcess = true;
                while (foundProcess)
                {
                    foundProcess = false;
                    for (int i = 0; i < numProcesses; i++)
                    {
                        if (!finish[i])
                        {
                            bool canFinish = true;
                            for (int j = 0; j < numResources; j++)
                            {
                                if (maximumNeed[i, j] - currentAllocation[i, j] > work[j])
                                {
                                    canFinish = false;
                                    break;
                                }
                            }
                            if (canFinish)
                            {
                                // Finish process i and release its resources
                                for (int j = 0; j < numResources; j++)
                                {
                                    work[j] += currentAllocation[i, j];
                                }
                                finish[i] = true;
                                foundProcess = true;
                            }
                        }
                    }
                }

                // Check if resource request can be satisfied
                if (!finish[processNum - 1])
                {
                    for (int j = 0; j < numResources; j++)
                    {
                        if (resourceAmount > work[j])
                        {
                            return false;
                        }
                    }
                }

                return true; */


/* private void textBox1_TextChanged(object sender, EventArgs e)
 {
     // Check if resource request is valid using Banker's Algorithm
     if (IsSafeState(numProcesses, numResources, totalResources, availableResources, currentAllocation, maximumNeed, numProcesses ,numResources , resourceAmount))
     {
         // Grant resource request
         availableResources[numResources - 1] -= resourceAmount;
         currentAllocation[numProcesses - 1, numResources - 1] += resourceAmount;
         maximumNeed[numProcesses - 1, numResources - 1] -= resourceAmount;
         Console.WriteLine("Resource request granted.");
     }
     else
     {
         // Deny resource request
         Console.WriteLine("Resource request denied.");
     }
 } */











/* int[] work = new int[numResources];
 for (int i = 0; i < numResources; i++)
 {
     work[i] = availableResources[i];
 }

 bool[] finish = new bool[numProcesses];
 for (int i = 0; i < numProcesses; i++)
 {
     finish[i] = false;
 }

 int[,] need = new int[numProcesses, numResources];
 for (int i = 0; i < numProcesses; i++)
 {
     for (int j = 0; j < numResources; j++)
     {
         need[i, j] = maximumNeed[i, j] - currentAllocation[i, j];
     }
 } */

// Find a safe sequence of processes
/* bool safeSequenceFound = true;
 int[] safeSequence = new int[numProcesses];
 int count = 0;
 while (count < numProcesses)
 {
     bool found = false;
     for (int i = 0; i < numProcesses; i++)
     {
         if (!finish[i])
         {
             bool canExecute = true;
             for (int j = 0; j < numResources; j++)
             {
                 if (need[i, j] > work[j])
                 {
                     canExecute = false;
                     break;
                 }
             }
             if (canExecute)
             {
                 found = true;
                 finish[i] = true;
                 safeSequence[count] = i;
                 count++;
                 for (int j = 0; j < numResources; j++)
                 {
                     work[j] += currentAllocation[i, j];
                 }
             }
         }
     }
 } */







