﻿window.addEventListener("load", () => {
    //localStorage.clear();
    UpdateCartButton();
});

function UpdateCartButton() {
    document.getElementsByClassName('amount-in-cart')[0].innerHTML = localStorage.length;
}

function DetailedPageOnLoad() {
    var button = document.getElementsByClassName('btn-add-cart-item')[0];
    button.addEventListener('click', AddCartItem);
}

function AddCartItem() {
    var movieItem = document.getElementsByClassName('movie-titel')[0];
    for (var i = 0; i < localStorage.length; i++) {
        if (movieItem.id === localStorage.key(i)) {
            var localStorageItem = JSON.parse(localStorage.getItem(movieItem.id));
            localStorageItem.qty++;
            localStorage.setItem(localStorage.key(i), JSON.stringify(localStorageItem));
            return;
        }
    }
    var imdbid = movieItem.id;
    var title = movieItem.innerHTML;
    var price = document.getElementsByClassName('btn-add-cart-item')[0].innerHTML.replace(' SEK', '');
    var posterurl = document.getElementsByClassName('movie')[0].getAttribute('src');
    localStorage.setItem(imdbid, JSON.stringify({imdbid, title, price, qty: 1, posterurl, detailid: window.location.pathname }));
    document.getElementsByClassName('amount-in-cart')[0].innerHTML = localStorage.length;
}

function CartOnLoad() {
    var totalPrice = 0;
    var cartItems = document.getElementsByClassName('cart-items')[0];

    for (var i = 0; i < localStorage.length; i++) {
        var localStorageItem = JSON.parse(localStorage.getItem(localStorage.key(i)));
        var cartItem = document.createElement('div');
        cartItem.classList.add('cart-item');
        cartItem.id = localStorage.key(i);
        var cartItemSumPrice = (localStorageItem.price * localStorageItem.qty);

        cartItem.innerHTML =
            `<div class="cart-item-box">
                <img src=${localStorageItem.posterurl} width="125px" class="cart-poster"/>
                <div class="cart-item-info">                                                   
                    <div class="cart-item-ind-title"><span class="cart-item-title"><a href="..${localStorageItem.detailid}">${localStorageItem.title}</a></span></div>
                    <div class="cart-item-ind-price"><span class="cart-item-price">${localStorageItem.price} kr</span></div>
                </div>
                <div class="qty-price">
                    <div class="cart-qty">
                        <label>Qty: </label>
                        <input class="cart-item-qty" type="number" value="${localStorageItem.qty}" />
                    </div>
                    <div class="cart-pricing">
                        <span class="cart-item-sum-price">${cartItemSumPrice} kr </span>
                        <button class="btn btn-delete">Delete</button>
                    </div>
                </div>
            `;

        cartItems.append(cartItem);
        totalPrice += cartItemSumPrice;
    }

    document.getElementsByClassName('cart-total-price')[0].innerHTML = totalPrice + ' kr';

    var deleteCartItemButtons = document.getElementsByClassName('btn-delete');
    for (var i = 0; i < deleteCartItemButtons.length; i++) {
        var button = deleteCartItemButtons[i];
        button.addEventListener('click', DeleteCartItem);
    }

    var changeQtyInputs = document.getElementsByClassName('cart-item-qty');
    for (var i = 0; i < changeQtyInputs.length; i++) {
        var input = changeQtyInputs[i];
        input.addEventListener('change', QtyChanged);
    }

    document.getElementsByClassName('btn-to-clear-cart')[0].addEventListener('click', ClearCart);
}

function UpdateCart() {
    var totalPrice = 0;

    if (localStorage.length === 0) {
        var cartItems = document.getElementsByClassName('cart-items')[0];
        cartItems.innerHTML = '';
        var emptyCart = document.createElement('div');
        emptyCart.innerHTML = 'No movies in cart!'; // Cart item when empty
        cartItems.append(emptyCart);
    }
    else {
        for (var i = 0; i < localStorage.length; i++) {
            var localStorageItem = JSON.parse(localStorage.getItem(localStorage.key(i)));
            var cartItemSumPrice = (localStorageItem.price * localStorageItem.qty);
            var cartItem = document.getElementById(localStorageItem.imdbid);
            cartItem.getElementsByClassName('cart-item-sum-price')[0].innerHTML = cartItemSumPrice + ' kr';
            totalPrice += cartItemSumPrice;
        }
    }

    document.getElementsByClassName('cart-total-price')[0].innerHTML = totalPrice + ' kr';
}

function DeleteCartItem(event) {
    var buttonClicked = event.target;
    var cartItem = buttonClicked.parentElement.parentElement.parentElement.parentElement;
    localStorage.removeItem(cartItem.id);
    cartItem.remove();

    UpdateCart();
    document.getElementsByClassName('amount-in-cart')[0].innerHTML = localStorage.length;
}

function QtyChanged(event) {
    var input = event.target;
    if (!Number.isInteger(parseFloat(input.value)) || input.value <= 0) {
        input.value = 1;
    }

    var cartItem = input.parentElement.parentElement.parentElement.parentElement;
    var localStorageItem = JSON.parse(localStorage.getItem(cartItem.id));
    localStorageItem.qty = input.value;
    localStorage.setItem(localStorageItem.imdbid, JSON.stringify(localStorageItem));

    UpdateCart();
}

function ClearCart() {
    localStorage.clear();
    UpdateCart();
    document.getElementsByClassName('amount-in-cart')[0].innerHTML = localStorage.length;
}

function CheckoutOnLoad() {
    var totalPrice = 0;
    var cartItems = document.getElementsByClassName('checkout-items')[0];

    for (var i = 0; i < localStorage.length; i++) {
        var localStorageItem = JSON.parse(localStorage.getItem(localStorage.key(i)));
        var cartItem = document.createElement('div');
        cartItem.classList.add('checkout-item');
        cartItem.id = localStorage.key(i);
        var cartItemSumPrice = (localStorageItem.price * localStorageItem.qty);

        cartItem.innerHTML =
            `<div class="checkout-item-box">
                <img src=${localStorageItem.posterurl} width="47px" class="checkout-poster"/>
                <div class="checkout-item-info">                                                   
                    <div class="checkout-item-ind-title"><span class="checkout-item-title">${localStorageItem.title}</span></div>
                    <br />
                    <div class="checkout-item-ind-price"><span class="checkout-item-price">${localStorageItem.price} kr</span></div>  
                </div>
                <div class="qty-price">
                    <div class="checkout-qty">
                        <p>Qty: ${localStorageItem.qty}</p>
                    </div>
                    <div class="checkout-pricing">
                        <span class="checkout-item-sum-price">${cartItemSumPrice} kr </span>
                    </div>
            </div>`;

        cartItems.append(cartItem);
        totalPrice += cartItemSumPrice;
    }
    document.getElementsByClassName('checkout-total-price')[0].innerHTML = totalPrice + ' kr';
}