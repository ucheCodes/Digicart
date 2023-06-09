﻿using HKBlog.Models;
using HKBlog.States.SubStates;

namespace HKBlog.States
{
    public class State
    {
        public LoginClicker LoginClicker { get; set; } = new LoginClicker(false);
        public ActiveUser ActiveUser { get; set; } = new ActiveUser(new User());
        public ShowCartClicker CartClicker { get; set; } = new ShowCartClicker(false);
        public ShowUploadClicker UploadClicker { get; set; } = new ShowUploadClicker(false);
        public ProductUploadVal ProductVal { get; set; } = new ProductUploadVal(new Product());
        public Cart Cart { get; set; } = new Cart(new());
        public ProductItems ProductItems { get; set; } = new ProductItems(new());
        public CartTotal CartTotal { get; set; } = new CartTotal(0);
        public PaystackAuthorisation PaystackAuthUrl { get; set; } = new PaystackAuthorisation(new());
    }
    public class Store : IStore
    {
        private State state = new State();
        public State State() { return state; }
        #region Mutations
        public void LoginClick(bool clickVal)
        {
            state.LoginClicker = new LoginClicker(clickVal);
            BroadcastStateChanged();
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
            BroadcastStateChanged();
        }
        public void AddToCart(Product product)
        {
            var products = state.Cart.Items.ToList();
            if (!products.Contains(product))
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
            if (products.Contains(product))
            {
                products.Remove(product);
                state.Cart = new Cart(products);
                ComputeCartTotal();
                BroadcastStateChanged();
            }
        }
        public void ComputeCartTotal()
        {
            int total = 0;
            foreach (var item in state.Cart.Items)
            {
                total += (item.Price * item.Quantity);
            }
            state.CartTotal = new CartTotal(total);
            BroadcastStateChanged();
        }
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