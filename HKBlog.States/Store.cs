using HKBlog.Models;
using HKBlog.States.SubStates;
//using static System.Formats.Asn1.AsnWriter;

namespace HKBlog.States
{
    public class State
    {
        public LoginClicker LoginClicker { get; set; } = new LoginClicker(false,false);
        public ActiveUser ActiveUser { get; set; } = new ActiveUser(new User());
        public ShowCartClicker CartClicker { get; set; } = new ShowCartClicker(false);
        public ShowUploadClicker UploadClicker { get; set; } = new ShowUploadClicker(false);
        public ProductUploadVal ProductVal { get; set; } = new ProductUploadVal(new Product());
        public Cart Cart { get; set; } = new Cart(new());
        public ProductItems ProductItems { get; set; } = new ProductItems(new());
        public CartTotal CartTotal { get; set; } = new CartTotal(0);
        public PaystackAuthorisation PaystackAuthUrl { get; set; } = new PaystackAuthorisation(new());
        public ProductCategoryList CategoryList { get; set; } = new ProductCategoryList(new());
        public ProductReviews Reviews { get; set; } = new ProductReviews(new List<Review>());
        public PaystackCharge Paystack { get; set; } = new(new());
        public SelectedPaymentChannel ProductPaymentChannel { get; set; } = new("");
        public UsersList Users { get; set; } = new(new());
        public NewOrderList NewOrders { get; set; } = new(new());
        public OrderList Orders { get; set; } = new(new());
        public Notifications Notifications { get; set; } = new(new());
        public ProjectName Project{ get; set; } = new(new(""));
        public AllWalletsInformation AllWalletsInfo { get; set; } = new(new(), new());
        public DispatchedData Dispatched { get; set; } = new(new());
        public double LogisticFee { get; set; } = 0;
    }
    public class Store : IStore
    {
        private State state = new State();
        public State State() { return state; }
        #region Mutations
        public void LoginClick(bool showLogin, bool showSignup)
        {
            state.LoginClicker = new LoginClicker(showLogin,showSignup);
            BroadcastStateChanged();
        }
        public void SetProductCategoryList(List<string> category)
        {
            state.CategoryList = new ProductCategoryList(category);
        }
        public void SetProductReviews(List<Review> reviews)
        {
            state.Reviews = new ProductReviews(reviews);
        }
        public  void SetPaystackAuthenticationUrl(bool key,string value)
        {
            state.PaystackAuthUrl = new PaystackAuthorisation(new KeyValuePair<bool, string>(key, value));
            BroadcastStateChanged();
        }
        public void ShowCart(bool showCart)
        {
            state.CartClicker = new ShowCartClicker(showCart);
            BroadcastStateChanged();
        }
        public void ShowUpload(bool showUpload)
        {
            state.UploadClicker = new ShowUploadClicker(showUpload);
            BroadcastStateChanged();
        }
        public void AddActiveUser(User user)
        {
            state.ActiveUser = new ActiveUser(user);
            BroadcastStateChanged();
        }
        public void ChangeProductVal(Product product)
        {
            state.ProductVal = new ProductUploadVal(product);
            BroadcastStateChanged();    
        }
        public void UpdateProducts(List<Product> products)
        {
            //var productItems = state.ProductItems.Products;
            state.ProductItems = new ProductItems(products);
            //BroadcastStateChanged();
        }
        public void AddToCart(Product product)
        {
            var products = state.Cart.Items.ToList();
            if (!products.Any(p => p.Id.Equals(product.Id)))
            {
                products.Add(product);
                state.Cart = new Cart(products);
                ComputeCartTotal();
                BroadcastStateChanged();
            }
        }
        public void RemoveFromCart(Product product)
        {
            var products = state.Cart.Items.ToList();
            if (products.Any(p => p.Id.Equals(product.Id)))
            {
                products.Remove(product);
                state.Cart = new Cart(products);
                ComputeCartTotal();
                BroadcastStateChanged();
            }
        }
        public void ClearCart()
        {
			state.Cart = new Cart(new());
			ComputeCartTotal();
            BroadcastStateChanged();
		}
        public void ComputeCartTotal()
        {
            double total = 0;//add paystack's #100 to logistics
            foreach (var item in state.Cart.Items)
            {
                total += (item.Price * item.Quantity);
            }
            if (state.ProductPaymentChannel.Channnel.Equals("paystack"))
            {
                ComputePaystackCharges(total);
				total += state.Paystack.Charge;
			}
            total = Math.Ceiling(total);
            state.CartTotal = new CartTotal(total);
            BroadcastStateChanged();
        }
        private void ComputePaystackCharges(double cartTotal)
        {
            double charge = 0.05 * cartTotal;
            double roundedValue = Math.Ceiling(charge);
            if (cartTotal > 1500)
            {
				state.Paystack = new PaystackCharge((roundedValue + 100));
            }
            else
            {
				state.Paystack = new PaystackCharge(roundedValue);
			}
            
		}
        public void ModifySelectedPaymentChannel(string channel)
        {
            state.ProductPaymentChannel = new SelectedPaymentChannel(channel);
            ComputeCartTotal();
        }
        public void UpdateUsersList(List<User> users)
        {
            state.Users = new UsersList(users);
        }
        public void UpdateNewOrders(List<NewOrder> data)
        {
            state.NewOrders = new NewOrderList(data);
        }
        public void UpdateAccountNotifications(List<AccountNotification> data)
        {
            state.Notifications = new Notifications(data);
        }
        public void UpdateOrders(List<Orders> orders)
        {
            state.Orders = new OrderList(orders);
        }
        public void AddProjectName(string name)
        {
            state.Project = new ProjectName(name);
        }
        public void UpdateWalletsInformation(List<Wallet> wallets, List<AccountNotification> notifs)
        {
            state.AllWalletsInfo = new(wallets, notifs);
        }
        public void UpdateDispatchedProducts(List<DispatchProduct> products)
        {
            state.Dispatched = new DispatchedData(products);

        }
        #endregion
        #region GeneralCodes

        #endregion
        #region observer patterns
        //Define events that will listen for changes
        private Action? _listeners;
        public void AddStateChangedListeners(Action? listeners)
        {
            _listeners += listeners;
        }
        public void RemoveStateChangedListeners(Action? listeners)
        {
            _listeners -= listeners;
        }
        public void BroadcastStateChanged()
        {
            _listeners?.Invoke();
        }
        #endregion
    }
}