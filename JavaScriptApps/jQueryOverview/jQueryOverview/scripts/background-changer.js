/// <reference path="jquery-2.0.2.js" />
$(document).ready(
   function () {
       var inputField = $('#Callbacks');
       inputField.jPicker(
         {},
         function (color, context) {
             var all = color.val('all');
             
             $('body').css(
               {
                   backgroundColor: all && '#' + all.hex || 'transparent'
               }); // prevent IE from throwing exception if hex is empty
         },
        
         function (color, context) {
           
         });
       inputField.attr('style','display:none');
   });