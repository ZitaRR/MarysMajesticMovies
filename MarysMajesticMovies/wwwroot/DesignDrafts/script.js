var id = 25; // Total number of images
var ranimage = new Array("Filmer/1.jpg","Filmer/2.jpg","Filmer/3.jpg","Filmer/4.jpg"
,"Filmer5/.jpg","Filmer/6.jpg","Filmer/7.jpg","Filmer/8.jpg","Filmer/9.jpg"
,"Filmer/10.jpg","Filmer/11.jpg","Filmer/12.jpg","Filmer/13.jpg","Filmer/14.jpg"
,"Filmer/15.jpg","Filmer/16.jpg","Filmer/17.jpg","Filmer/18.jpg","Filmer/19.jpg"
,"Filmer/20.jpg","Filmer/21.jpg","Filmer/22.jpg","Filmer/23.jpg","Filmer/24.jpg"
,"Filmer/25.jpg");

ImageArray = new Array();
ImageArray[0] = "1.jpg";
ImageArray[1] = "2.jpg";
ImageArray[2] = "3.jpg";
ImageArray[3] = "4.jpg";
ImageArray[4] = "5.jpg";
ImageArray[5] = "6.jpg";
ImageArray[6] = "7.jpg";
ImageArray[7] = "8.jpg";
ImageArray[8] = "9.jpg";
ImageArray[9] = "10.jpg";
ImageArray[10] = "11.jpg";
ImageArray[11] = "12.jpg";
ImageArray[12] = "13.jpg";
ImageArray[13] = "14.jpg";
ImageArray[14] = "15.jpg";
ImageArray[15] = "16.jpg";
ImageArray[16] = "17.jpg";
ImageArray[17] = "18.jpg";
ImageArray[18] = "19.jpg";
ImageArray[19] = "20.jpg";
ImageArray[20] = "21.jpg";
ImageArray[21] = "22.jpg";
ImageArray[22] = "23.jpg";
ImageArray[23] = "24.jpg";
ImageArray[24] = "25.jpg";

function getRandomImage() {
    var num = Math.floor( Math.random() * 11);
    var img = ImageArray[num];
    document.getElementById("randImage").innerHTML = ('<img src="' + 'Filmer/' + img + '" width="250px" class="movie">')

}

function randomImg(){
        let all = []
        let collection = {}
        for (let i = 1; i < 55; i++) {
            var randomNumber = Math.floor(Math.random() * 25) + 1;
            var imgName = randomNumber + ".jpg";
            let src = "DesignDrafts/Filmer/" + imgName;
            all.push([src, randomNumber])
            if (!collection[randomNumber]) {
                collection[randomNumber] = 1; // this will be for count the appearances of the img
            } else {
                collection[randomNumber] += 1;
            }
        }
        for (image of all) {
            src = image[0]
            randomNumber = image[1]
            percent = collection[randomNumber] / 25
            document.getElementById("popular").innerHTML += `<img class="movie" src=${src} />`
        }
}

function randomImg2(){
        let all = []
        let collection = {}
        for (let i = 1; i < 55; i++) {
            var randomNumber = Math.floor(Math.random() * 25) + 1;
            var imgName = randomNumber + ".jpg";
            let src = "DesignDrafts/Filmer/" + imgName;
            all.push([src, randomNumber])
            if (!collection[randomNumber]) {
                collection[randomNumber] = 1; // this will be for count the appearances of the img
            } else {
                collection[randomNumber] += 1;
            }
        }
        for (image of all) {
            src = image[0]
            randomNumber = image[1]
            percent = collection[randomNumber] / 25
            document.getElementById("blockbusters").innerHTML += `<img class="movie" src=${src} />`
        }
}

function randomImg3(){
        let all = []
        let collection = {}
        for (let i = 1; i < 55; i++) {
            var randomNumber = Math.floor(Math.random() * 25) + 1;
            var imgName = randomNumber + ".jpg";
            let src = "DesignDrafts/Filmer/" + imgName;
            all.push([src, randomNumber])
            if (!collection[randomNumber]) {
                collection[randomNumber] = 1; // this will be for count the appearances of the img
            } else {
                collection[randomNumber] += 1;
            }
        }
        for (image of all) {
            src = image[0]
            randomNumber = image[1]
            percent = collection[randomNumber] / 25
            document.getElementById("justForYou").innerHTML += `<img class="movie" src=${src} />`
        }
}

function randomImg4(){
        let all = []
        let collection = {}
        for (let i = 1; i < 55; i++) {
            var randomNumber = Math.floor(Math.random() * 25) + 1;
            var imgName = randomNumber + ".jpg";
            let src = "DesignDrafts/Filmer/" + imgName;
            all.push([src, randomNumber])
            if (!collection[randomNumber]) {
                collection[randomNumber] = 1; // this will be for count the appearances of the img
            } else {
                collection[randomNumber] += 1;
            }
        }
        for (image of all) {
            src = image[0]
            randomNumber = image[1]
            percent = collection[randomNumber] / 25
            document.getElementById("movieDeals").innerHTML += `<img class="movie" src=${src} />`
        }
}

function randomImg5(){
        let all = []
        let collection = {}
        for (let i = 1; i < 55; i++) {
            var randomNumber = Math.floor(Math.random() * 25) + 1;
            var imgName = randomNumber + ".jpg";
            let src = "DesignDrafts/Filmer/" + imgName;
            all.push([src, randomNumber])
            if (!collection[randomNumber]) {
                collection[randomNumber] = 1; // this will be for count the appearances of the img
            } else {
                collection[randomNumber] += 1;
            }
        }
        for (image of all) {
            src = image[0]
            randomNumber = image[1]
            percent = collection[randomNumber] / 25
            document.getElementById("latest").innerHTML += `<img class="movie" src=${src} />`
        }
}
function openNav() {
    document.getElementById("mySidebar").style.width = "250px";
    document.getElementById("mainpagebody").style.marginLeft = "250px";
}

function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    document.getElementById("mainpagebody").style.marginLeft = "0";
}

function openNavRight() {
    document.getElementById("mySidebarRight").style.width = "250px";
    document.getElementById("mainpagebody").style.marginRight = "250px";
}

function closeNavRight() {
    document.getElementById("mySidebarRight").style.width = "0";
    document.getElementById("mainpagebody").style.marginRight = "0";
}
