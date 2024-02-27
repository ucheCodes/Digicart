using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
	public class PaystackCharge
	{
		public double Charge { get;}
		public PaystackCharge(double value)
		{
			Charge = value;
		}
	}
	public class SelectedPaymentChannel
	{
		public string Channnel { get;} = string.Empty;
		public SelectedPaymentChannel(string channnel)
		{
			Channnel = channnel;
		}
	}
}
