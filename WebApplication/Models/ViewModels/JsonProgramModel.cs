using RepoAndUnitOfWork.Concrete;
using RepoAndUnitOfWork.Entities;
using RepoAndUnitOfWorkJSON.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Models
{
    public class JsonProgramModel
    {
        public Programme ProgramJson { get; set; } = new Programme();

        public JsonProgramModel()
        {
            setChannelIcon();
        }
        public void SetTime()
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 1, 0, 0, 0, DateTimeKind.Local);
            dateTime = dateTime.AddSeconds(Convert.ToInt32(ProgramJson.start));
            ProgramJson.StartTime = dateTime;

            DateTime dateTimeStop = new DateTime(1970, 1, 1, 1, 0, 0, 0, DateTimeKind.Local);
            dateTimeStop = dateTimeStop.AddSeconds(Convert.ToInt32(ProgramJson.stop));
            ProgramJson.StopTime = dateTimeStop;

            SetPassedOrNotPassed(dateTime);
        }

        private void setChannelIcon()
        {
            ProgramJson.iconUrl = "http://logos.xmltv.se/" + ProgramJson.channel + ".png";
        }

        private void SetPassedOrNotPassed(DateTime dateTime)
        {
            int result = DateTime.Compare(dateTime, DateTime.Now);

            if (result < 0)
            {
                ProgramJson.HasPassed = "Passed";
            }
            else
            {
                ProgramJson.HasPassed = "NotPassed";
            }
        }
    }
}