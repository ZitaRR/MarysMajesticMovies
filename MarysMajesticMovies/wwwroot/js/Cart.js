//var cart = [];

if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', SiteLoaded);
}
else {
    SiteLoaded();
}

function SiteLoaded() {
    var addCartItemButtons = document.getElementsByClassName('btn-add');
    for (var i = 0; i < addCartItemButtons.length; i++) {
        var button = addCartItemButtons[i];
        button.addEventListener('click', AddCartItem);
    }
}

function AddCartItem(imdbid, title, price, qty) {

    localStorage.setItem('cartitem' + localStorage.length, JSON.stringify({ imdbid: imdbid, title: title, price: price, qty: qty }));
}

function CartOnLoad() {
    //localStorage.clear(); //Debug clear cart storage
    if (localStorage.length === 0) {
        localStorage.setItem('cartitem' + localStorage.length, JSON.stringify({ imdbid: "tt1234561", title: "Title1", qty: 1, price: 10 }));
        localStorage.setItem('cartitem' + localStorage.length, JSON.stringify({ imdbid: "tt1234563", title: "Title3", qty: 3, price: 30 }));
        localStorage.setItem('cartitem' + localStorage.length, JSON.stringify({ imdbid: "tt1234565", title: "Title5", qty: 5, price: 50 }));
        localStorage.setItem('cartitem' + localStorage.length, JSON.stringify({ imdbid: "tt1234567", title: "Title7", qty: 7, price: 70 }));
    }   //Debug seed cart data

    var cartItems = document.getElementsByClassName('cart-items')[0];

    for (var i = 0; i < localStorage.length; i++) {
        var localStorageItem = JSON.parse(localStorage.getItem(localStorage.key(i)));

        var cartItem = document.createElement('div');
        cartItem.classList.add('cart-item');
        cartItem.id = localStorage.key(i);

        var cartItemContent = `
            <div class="cart-item-info">
                <span class="cart-item-title">${localStorageItem.title}</span>
                <span class="cart-item-price">${localStorageItem.price} kr</span>
            </div>
            <div class="cart-qty" style="max-width: 100px">
                <label>Qty: </label>
                <input class="cart-item-qty" type="number" value="${localStorageItem.qty}" />
            </div>
            <span class="cart-item-sum-price">${localStorageItem.price * localStorageItem.qty} kr </span>
            <button class="btn btn-delete">Delete</button>
            <br />
            <br />
            <br />`; // Cart item design
        cartItem.innerHTML = cartItemContent;
        cartItems.append(cartItem);
    }

    UpdateCart();

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

    document.getElementsByClassName('btn-to-clear-cart')[0].addEventListener('click', ClearCart);;

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
        var allCartItems = document.getElementsByClassName('cart-item');

        for (var i = 0; i < allCartItems.length; i++) {
            var localStorageCartItem = JSON.parse(localStorage.getItem(localStorage.key(i)));
            var cartItemSumPrice = (localStorageCartItem.price * localStorageCartItem.qty);
            var cartItem = allCartItems[i];
            cartItem.getElementsByClassName('cart-item-sum-price')[0].innerHTML = cartItemSumPrice + ' kr';
            totalPrice += cartItemSumPrice;
        }
    }

    document.getElementsByClassName('cart-total-price')[0].innerHTML = totalPrice + ' kr';
}

function DeleteCartItem(event) {
    var buttonClicked = event.target;

    localStorage.removeItem(buttonClicked.parentElement.id);
    buttonClicked.parentElement.remove();

    UpdateCart();
}

function QtyChanged(event) {
    var input = event.target;
    if (!Number.isInteger(parseFloat(input.value)) || input.value <= 0) {
        input.value = 1;
    }

    var cartItemId = input.parentElement.parentElement.id;
    var localStorageItem = JSON.parse(localStorage.getItem(cartItemId));
    localStorageItem.qty = input.value;
    localStorage.setItem(cartItemId, JSON.stringify(localStorageItem));

    UpdateCart();
}

function ClearCart() {
    localStorage.clear();
    UpdateCart();
}