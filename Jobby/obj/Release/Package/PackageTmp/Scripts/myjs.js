

// CKEditor


// scale size for searchtext on blur/focus in navebar;
try {
    var searchbar = document.getElementById("searching");
    searchbar.onfocus = function () { searchbar.setAttribute("placeholder", " "); };
    searchbar.onblur = function () {
        "use strict";
        searchbar.setAttribute("placeholder", "Find your job");

    };
}

catch{ }

////                   end                          ////



/// in category index hide/show icons for edit and delete  category for Admins
var categorydiv = document.getElementsByClassName("jobcatdiv");
var managecat = document.getElementsByClassName("catmang");

for (var i = 0; i < categorydiv.length; i++) {

    categorydiv[i].onmouseover = function () {

        this.lastElementChild.style.visibility = "visible";

    };

}

for (var i = 0; i < categorydiv.length; i++) {

    categorydiv[i].onmouseleave = function () {

        this.lastElementChild.style.visibility = "hidden";

    };

}

////////////// End////////////////



/// in Users index hide/show icons for Display user profile or  deleting   .for Admins
var userframees = document.getElementsByClassName("userframe")

for (var i = 0; i < userframees.length; i++) {

    userframees[i].onmouseover = function () {

        this.lastElementChild.style.visibility = "visible";

    };

}


for (var i = 0; i < userframees.length; i++) {

    userframees[i].onmouseleave = function () {
        this.lastElementChild.style.visibility = "hidden";


    }

}

var applicationframecandidates = document.getElementsByClassName("applicationframecandidate");
for (var i = 0; i < applicationframecandidates.length; i++) {

    applicationframecandidates[i].onmouseover = function () {
        this.lastElementChild.style.visibility = "visible";



    };
}


for (var i = 0; i < applicationframecandidates.length; i++) {

    applicationframecandidates[i].onmouseleave = function () {
        this.lastElementChild.style.visibility = "hidden";



    };


}


////// user Save Application////

var saved = "glyphicon glyphicon-star  saveapp pull-right";
var notsave = "glyphicon glyphicon-star-empty  saveapp pull-right";
var save = document.getElementsByClassName("saveapp");
var t_f = 1;

for (var i = 0; i < save.length; i++) {
    save[i].onclick = function () {


        if (t_f == 1) {
            this.setAttribute("class", saved);

            t_f = 0;
        }
        else if (t_f == 0) {
            this.setAttribute("class", notsave);
            t_f = 1;
        }

    };

}


//////////////////////


//register//
//var usertype = document.getElementById("usertype");
//usertype.onchange = function () {
//    if (this.value == "Candidate") { }//add some Field
//        //*more section //


//};





//jobdetailss = document.getElementById("jobdetails");
//jobdetailss.onmouseover = function () {
//    document.getElementById("applyorsavejob").style.visibility = "visible";


//};

//jobdetailss.onmouseleave = function () {
//    document.getElementById("applyorsavejob").style.visibility = "hidden";


//}
//////////////// show /hide section in register form //////////////
regas = document.getElementById("usertype");
showforcn = document.getElementById("showWorkField");
showeduFields = document.getElementById("showeduField");
try {
    regas.onchange = function () {
        if (this.value == "Candidate") {
            showforcn.style.display = "block";
            showeduFields.style.display = "block";

        }

        else {
            showforcn.style.display = "none";
            showeduFields.style.display = "none";

        }


    }
}

catch{ }


///////////////////////////////////////////////







