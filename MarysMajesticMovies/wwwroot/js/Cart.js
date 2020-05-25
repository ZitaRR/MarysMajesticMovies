//var cart = [];

if (document.readyState == 'loading') {
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
    localStorage.clear(); //Debug clear cart storage
    if (localStorage.length == 0) {
        localStorage.setItem('cartitem' + localStorage.length, JSON.stringify({ imdbid: "tt1234567", title: "Title1", qty: 3, price: 50 }));
        localStorage.setItem('cartitem' + localStorage.length, JSON.stringify({ imdbid: "tt1234568", title: "Title2", qty: 4, price: 100 }));
    }   //Debug data
    var cartItems = document.getElementsByClassName('cart-items')[0];

    if (localStorage.length == 0) {
        var emptyCart = document.createElement('div');
        emptyCart.innerHTML = 'No movies in cart!'; // Cart item when empty
        cartItems.append(emptyCart);
        return;
    }

    for (var i = 0; i < localStorage.length; i++) {
        var localStorageItem = JSON.parse(localStorage.getItem('cartitem' + i));

        var cartItem = document.createElement('div');
        cartItem.classList.add('cart-item');
        cartItem.id = 'cartitem' + i;

        var cartItemContent = `
            <div class="cart-item-info">
                <span class="cart-item-title">${localStorageItem.title}</span>
                <span class="cart-item-price">${localStorageItem.price} kr</span>
            </div>
            <div class="cart-qty">
                <input class="cart-item-qty" type="number" value="${localStorageItem.qty}" />
            </div>
            <span class="cart-item-sum-price">${localStorageItem.price * localStorageItem.qty} kr </span>
            <button class="btn btn-delete">Delete</button>`; // Cart item design
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
}

function UpdateCart() {
    var allCartItems = document.getElementsByClassName('cart-item');
    var totalPrice = 0;

    if (localStorage.length == 0) {
        var cartItems = document.getElementsByClassName('cart-items')[0];
        var emptyCart = document.createElement('div');
        emptyCart.innerHTML = 'No movies in cart!'; // Cart item when empty
        cartItems.append(emptyCart);
    }
    else {
        for (var i = 0; i < allCartItems.length; i++) {
            var localStoreItem = JSON.parse(localStorage.getItem('cartitem' + i));
            var cartItemSumPrice = (localStoreItem.price * localStoreItem.qty);
            totalPrice += cartItemSumPrice;

            var cartItem = allCartItems[i];
            cartItem.getElementsByClassName('cart-item-sum-price')[0].innerHTML = cartItemSumPrice + ' kr';
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
    if (isNaN(input.value) || input.value <= 0) {
        input.value = 1;
    }

    var cartItemId = input.parentElement.parentElement.id;
    var localStorageItem = JSON.parse(localStorage.getItem(cartItemId));
    localStorageItem.qty = input.value;
    localStorage.setItem(cartItemId, JSON.stringify(localStorageItem));

    UpdateCart();
}