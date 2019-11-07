(function ($) {
    $(function () {

        $('.sidenav').sidenav();



        document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('.modal');
            var instances = M.Modal.init(elems, options);
        });

        // Or with jQuery

        $(document).ready(function () {
            $('.modal').modal();
        });

        document.addEventListener('DOMContentLoaded', function () {
            var elems = document.querySelectorAll('select');
            var instances = M.FormSelect.init(elems, options);
        });

        // Or with jQuery

        $(document).ready(function () {
            $('select').formSelect();
        });


        document.addEventListener('DOMContentLoaded', function() {
            var elems = document.querySelectorAll('.tooltipped');
            var instances = M.Tooltip.init(elems, options);
          });
        
          // Or with jQuery
        
          $(document).ready(function(){
            $('.tooltipped').tooltip();
          });
                


    }); // end of document ready
})(jQuery); // end of jQuery name space