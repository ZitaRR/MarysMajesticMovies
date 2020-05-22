if (document.readyState == 'loading') {
    document.addEventListener('DOMContentLoaded', ready);
}
else {
    ready();
}

function ready() {
    CartOnLoad();
    var addCartItemButtons = document.getElementsByClassName('btn-add');
    for (var i = 0; i < addCartItemButtons.length; i++) {
        var button = addCartItemButtons[i];
        button.addEventListener('click', AddCartItem)
    }
    var deleteCartItemButtons = document.getElementsByClassName('btn-delete');
    for (var i = 0; i < deleteCartItemButtons.length; i++) {
        var button = deleteCartItemButtons[i];
        button.addEventListener('click', deleteCartItem)
    }
}

function deleteCartItem(event) {
    var buttonClicked = event.target;
    buttonClicked.parentElement.remove();
}

function AddCartItem(imdbid, title, price, qty) {
    cartItems.push([imdbid, title, price, qty]);
}

function CartOnLoad() {
    var cartItems = document.getElementsByClassName('cart-items')[0];
    var cart = [];
    cart.push(['tt1232312', 'Title3', 40, 2]);
    cart.push(['tt4564567', 'Title4', 50, 3]);
    console.log(cartItems);

    for (var i = 0; i < cart.length; i++) {
        var cartRow = document.createElement('div');
        cartRow.classList.add('cart-rows');
        //cartRow.id(cart[i][0]);
        var cartRowContent = `
            <div class="cart-item">
                <span class="cart-item-title">${cart[i][1]}</span>
                <span class="cart-item-price">${cart[i][2]} kr</span>
            </div>
            <div class="cart-qty">
                <input class="cart-item-qty" type="number" value="${cart[i][3]}" />
            </div>
            <span class="cart-item-sum-price">${cart[i][2] * cart[i][3]}</span>
            <button class="btn btn-delete">Delete</button>`;
        cartRow.innerHTML = cartRowContent;
        cartItems.append(cartRow);
    }
}