
$(function() {		
	"use strict";
    $('.box').matchHeight();
});

var fullname = "John Doe";
var obj = {
     fullname: "Colin Ihrig",
     prop: {
          fullname: "Aurelio De Rosa",
          getFullName: function() {
               return this.fullname;
          }
     }
};

console.log(obj.prop.getFullName());

var test2 = obj.prop.getFullName;

console.log(test2());
