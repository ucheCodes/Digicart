using HKBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States
{
    public interface IStore
    {
        public State State();
        void LoginClick(bool showLogin, bool showSignup);
        void SetProductCategoryList(List<string> category);
        void SetProductReviews(List<Review> reviews);
        public void AddActiveUser(User user);
        void ShowCart(bool showCart);
        void ShowUpload(bool showUpload);
        void AddStateChangedListeners(Action? listeners);
        void RemoveStateChangedListeners(Action? listeners);
        void AddToCart(Product product);
        void RemoveFromCart(Product product);
        public void ClearCart();

		void ChangeProductVal(Product product);
        void UpdateProducts(List<Product> products);
        void ComputeCartTotal();
        void ModifySelectedPaymentChannel(string channel);
        void UpdateUsersList(List<User> users);
        void UpdateNewOrders(List<NewOrder> data);
        void UpdateAccountNotifications(List<AccountNotification> data);
        void UpdateOrders(List<Orders> orders);
        void SetPaystackAuthenticationUrl(bool key, string value);
        void AddProjectName(string name);
        void UpdateWalletsInformation(List<Wallet> wallets, List<AccountNotification> notifs);
    }
}
