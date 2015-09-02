using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using BitItApp.Models;

namespace BitItApp.Controllers
{
    public class BidDueDateManager
    {
        private Timer Timer;

        public BidDueDateManager()
        {
            Timer = null;

            InitTimer();
        }

        private void InitTimer()
        {
            try
            {
                //int Interval = Convert.ToInt32(ConfigurationManager.AppSettings["MessageTimerIntervalInSec"]);

                int interval = 1;

                Timer = new Timer();

                Timer.AutoReset = false;
                Timer.Interval = interval * 1000;
                Timer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);

                Timer.Start();
            }
            catch (Exception ex)
            {
            }
        }

        void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var itemsToRmove = new List<Item>();
                var items = DAL.Instance.GetItems();

                foreach (var item in items)
                {
                    int result = DateTime.Compare(DateTime.Now, item.DueDate);
                    bool isBidEnded = result > 0;
                    if (isBidEnded)
                    {
                        itemsToRmove.Add(item);
                    }     
                }

                foreach (var item in itemsToRmove)
                {
                    // Sending an email
                    //EmailSender.SendMail(item.)

                    items.Remove(item);
                }
            }
            catch (Exception ex)
            {
            }

            Timer.Start();
        }
    }
}