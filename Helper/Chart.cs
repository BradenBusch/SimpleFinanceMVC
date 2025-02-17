using SimpleFinance.Models;

namespace SimpleFinance.Helper
{
    public class Chart()
    {
        public static List<AccountDetail> GetDataSet(List<AccountDetail> details)
        {
            var detailsLength = details.Count;
            var orderedDetails = details.OrderBy(x => x.CreateDate).ToList();

            if (detailsLength <= 5)
            {
                return orderedDetails;
            }
            
            var firstDetail = orderedDetails.First();
            var thirdDetail = orderedDetails[detailsLength / 2];
            var fifthDetail = orderedDetails.Last();

            var secondIdx = (int)(detailsLength * .25);
            var fourthIdx = (int)(detailsLength * .75);
            var secondDetail = orderedDetails[secondIdx];
            var fourthDetail = orderedDetails[fourthIdx];

            return new List<AccountDetail> { firstDetail, secondDetail, thirdDetail, fourthDetail, fifthDetail };
        }
    }
}
