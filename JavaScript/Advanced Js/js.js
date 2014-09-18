//closure
var getCount = (function () {
    var counter = 0;
    return function () { return counter += 1; }
})();

window.onload = function()
{
    console.log(getCount());
    console.log(getCount.counter);
}