(function ($) {
   $.validator.setDefaults({
      ignore: []
   });
   $.validator.addMethod('data-val-trim',
      function (value, element, params) {
         if (value === null || value.trim().length === 0) {
            return false;
         }
         return true;
      }, function (params, element) {
         let msgCompare = $(element).attr('data-val-trim');
         if (!msgCompare) {
            msgCompare = 'Space invalid';
         }
         return msgCompare;
      });
   $.validator.unobtrusive.adapters.addBool('data-val-trim');
})(jQuery);