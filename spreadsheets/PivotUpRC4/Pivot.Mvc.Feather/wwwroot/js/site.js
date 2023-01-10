
UIkit.util.ready(function () {
  if (document.getElementById('js-progress') != null) {
    let bar = document.getElementById('js-progress');
    let animate = setInterval(function () {
      bar.value += 10;
      if (bar.value >= bar.max) {
        clearInterval(animate);
      }
    }, 500);
  }
});
