$(document).ready(function() {
    $('.burger').click(function() {
        $('.burger').toggleClass('open-menu');
        $('.neBurger').toggleClass('open-menu');
        $('body').toggleClass('fixed-page');
    });
});

const toClick = document.getElementById('toClick');
const list = document.querySelector('.years__hidden');
const neBurger = document.querySelector('.neBurger');

toClick.addEventListener('click', event => {
    list.classList.toggle('showList');
})