function hello(text) {
  alert(WAVE.strDefault(text, "Hello"));
}

function render(root, ctx){
var ljs_useCtx = WAVE.isObject(ctx);
var ljs_1 = document.createElement('div');
ljs_1.addEventListener('click', function() { console.log('kaka') }, false);
var ljs_2 = document.createElement('div');
var ljs_3 = "title";
ljs_3 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_3, ctx) : ljs_3;
ljs_2.setAttribute('class', ljs_3);
var ljs_4 = "alert(\x27just data\x27)";
ljs_4 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_4, ctx) : ljs_4;
ljs_2.setAttribute('data-alert', ljs_4);
var ljs_5 = "\x3Cscript\x3Ealert(\x22script\x22)\x3C\x2Fscript\x3E";
ljs_5 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_5, ctx) : ljs_5;
ljs_2.setAttribute('data-alert-script', ljs_5);
ljs_1.appendChild(ljs_2);
var ljs_6 = document.createElement('div');
var ljs_7 = "rate";
ljs_7 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_7, ctx) : ljs_7;
ljs_6.setAttribute('id', ljs_7);
ljs_1.appendChild(ljs_6);
var ljs_8 = document.createElement('div');
var ljs_9 = "@color@";
ljs_9 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_9, ctx) : ljs_9;
ljs_8.setAttribute('class', ljs_9);
ljs_1.appendChild(ljs_8);
var ljs_10 = document.createElement('div');
var ljs_11 = "stub @color@";
ljs_11 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_11, ctx) : ljs_11;
ljs_10.setAttribute('class', ljs_11);
ljs_1.appendChild(ljs_10);
var ljs_12 = document.createElement('div');
var ljs_13 = "\x3Cscript\x3Ealert(\x22\x27\x3Cscript\x3Ealert(\x27@color@\x27);\x3C\x2Fscript\x3E\x27text\x22)\x3C\x2Fscript\x3E";
ljs_13 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_13, ctx) : ljs_13;
ljs_12.innerText = ljs_13;
ljs_1.appendChild(ljs_12);
var ljs_14 = document.createElement('div');
var ljs_15 = document.createElement('div');
var ljs_16 = "@color@";
ljs_16 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_16, ctx) : ljs_16;
ljs_15.setAttribute('class', ljs_16);
var ljs_17 = document.createElement('div');
var ljs_18 = document.createElement('div');
var ljs_19 = "@color@";
ljs_19 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_19, ctx) : ljs_19;
ljs_18.setAttribute('class', ljs_19);
var ljs_20 = document.createElement('div');
var ljs_21 = document.createElement('div');
var ljs_22 = "@color@";
ljs_22 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_22, ctx) : ljs_22;
ljs_21.setAttribute('class', ljs_22);
var ljs_23 = document.createElement('div');
var ljs_24 = document.createElement('div');
var ljs_25 = "@color@";
ljs_25 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_25, ctx) : ljs_25;
ljs_24.setAttribute('class', ljs_25);
var ljs_26 = document.createElement('div');
var ljs_27 = ",.\x2F[\x5C]{}|!@#$%^\x26*()_+=-~`\x27";
ljs_27 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_27, ctx) : ljs_27;
ljs_26.innerText = ljs_27;
ljs_24.appendChild(ljs_26);
ljs_23.appendChild(ljs_24);
ljs_21.appendChild(ljs_23);
ljs_20.appendChild(ljs_21);
ljs_18.appendChild(ljs_20);
ljs_17.appendChild(ljs_18);
ljs_15.appendChild(ljs_17);
ljs_14.appendChild(ljs_15);
ljs_1.appendChild(ljs_14);
var ljs_28 = document.createElement('div');
var ljs_29 = "@height@";
ljs_29 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_29, ctx) : ljs_29;
ljs_28.setAttribute('data-height', ljs_29);
var ljs_30 = "@color@";
ljs_30 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_30, ctx) : ljs_30;
ljs_28.setAttribute('class', ljs_30);
ljs_1.appendChild(ljs_28);
var ljs_31 = document.createElement('div');
var ljs_32 = "controls";
ljs_32 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_32, ctx) : ljs_32;
ljs_31.setAttribute('id', ljs_32);
var ljs_33 = document.createElement('input');
var ljs_34 = "2013-06-06";
ljs_34 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_34, ctx) : ljs_34;
ljs_33.setAttribute('value', ljs_34);
var ljs_35 = "date";
ljs_35 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_35, ctx) : ljs_35;
ljs_33.setAttribute('type', ljs_35);
ljs_31.appendChild(ljs_33);
var ljs_36 = document.createElement('input');
var ljs_37 = "234.11";
ljs_37 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_37, ctx) : ljs_37;
ljs_36.setAttribute('value', ljs_37);
var ljs_38 = "text";
ljs_38 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_38, ctx) : ljs_38;
ljs_36.setAttribute('type', ljs_38);
ljs_31.appendChild(ljs_36);
var ljs_39 = document.createElement('input');
var ljs_40 = "234.11";
ljs_40 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_40, ctx) : ljs_40;
ljs_39.setAttribute('value', ljs_40);
var ljs_41 = "number";
ljs_41 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_41, ctx) : ljs_41;
ljs_39.setAttribute('type', ljs_41);
ljs_31.appendChild(ljs_39);
ljs_1.appendChild(ljs_31);
var ljs_42 = document.createElement('div');
var ljs_43 = "container";
ljs_43 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_43, ctx) : ljs_43;
ljs_42.setAttribute('id', ljs_43);
var ljs_44 = document.createElement('h1');
var ljs_45 = "Animation Test";
ljs_45 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_45, ctx) : ljs_45;
ljs_44.innerText = ljs_45;
ljs_42.appendChild(ljs_44);
var ljs_46 = document.createElement('button');
var ljs_47 = "Highlight";
ljs_47 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_47, ctx) : ljs_47;
ljs_46.innerText = ljs_47;
var ljs_48 = "highlight";
ljs_48 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_48, ctx) : ljs_48;
ljs_46.setAttribute('class', ljs_48);
ljs_46.addEventListener('click', function() { hello('highlight'); }, false);
ljs_42.appendChild(ljs_46);
var ljs_49 = document.createElement('button');
var ljs_50 = "Fade";
ljs_50 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_50, ctx) : ljs_50;
ljs_49.innerText = ljs_50;
var ljs_51 = "fade";
ljs_51 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_51, ctx) : ljs_51;
ljs_49.setAttribute('class', ljs_51);
ljs_49.addEventListener('click', function() { hello('fade'); }, false);
ljs_42.appendChild(ljs_49);
var ljs_52 = document.createElement('button');
var ljs_53 = "Rizzle";
ljs_53 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_53, ctx) : ljs_53;
ljs_52.innerText = ljs_53;
var ljs_54 = "rizzle";
ljs_54 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_54, ctx) : ljs_54;
ljs_52.setAttribute('class', ljs_54);
ljs_52.addEventListener('click', hello, false);
ljs_42.appendChild(ljs_52);
var ljs_55 = document.createElement('button');
var ljs_56 = "Knit";
ljs_56 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_56, ctx) : ljs_56;
ljs_55.innerText = ljs_56;
var ljs_57 = "knit";
ljs_57 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_57, ctx) : ljs_57;
ljs_55.setAttribute('class', ljs_57);
ljs_55.addEventListener('click', hello, false);
ljs_42.appendChild(ljs_55);
var ljs_58 = document.createElement('button');
var ljs_59 = "Shrink";
ljs_59 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_59, ctx) : ljs_59;
ljs_58.innerText = ljs_59;
var ljs_60 = "shrink";
ljs_60 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_60, ctx) : ljs_60;
ljs_58.setAttribute('class', ljs_60);
ljs_58.addEventListener('click', hello, false);
ljs_42.appendChild(ljs_58);
var ljs_61 = document.createElement('button');
var ljs_62 = "Rotate";
ljs_62 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_62, ctx) : ljs_62;
ljs_61.innerText = ljs_62;
var ljs_63 = "rotate";
ljs_63 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_63, ctx) : ljs_63;
ljs_61.setAttribute('class', ljs_63);
ljs_61.addEventListener('click', hello, false);
ljs_42.appendChild(ljs_61);
var ljs_64 = document.createElement('button');
var ljs_65 = "Boom";
ljs_65 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_65, ctx) : ljs_65;
ljs_64.innerText = ljs_65;
var ljs_66 = "boom";
ljs_66 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_66, ctx) : ljs_66;
ljs_64.setAttribute('class', ljs_66);
ljs_64.addEventListener('click', hello, false);
ljs_42.appendChild(ljs_64);
var ljs_67 = document.createElement('button');
var ljs_68 = "Squeeze";
ljs_68 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_68, ctx) : ljs_68;
ljs_67.innerText = ljs_68;
var ljs_69 = "squeeze";
ljs_69 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_69, ctx) : ljs_69;
ljs_67.setAttribute('class', ljs_69);
ljs_67.addEventListener('click', hello, false);
ljs_42.appendChild(ljs_67);
var ljs_70 = document.createElement('button');
var ljs_71 = "Deform";
ljs_71 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_71, ctx) : ljs_71;
ljs_70.innerText = ljs_71;
var ljs_72 = "deform";
ljs_72 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_72, ctx) : ljs_72;
ljs_70.setAttribute('class', ljs_72);
ljs_70.addEventListener('click', hello, false);
ljs_42.appendChild(ljs_70);
ljs_1.appendChild(ljs_42);
var ljs_73 = document.createElement('h1');
var ljs_74 = "Compiler output example";
ljs_74 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_74, ctx) : ljs_74;
ljs_73.innerText = ljs_74;
ljs_1.appendChild(ljs_73);
var ljs_75 = document.createElement('code');
var ljs_76 = "\x0D\x0A      function noRoot() {\x0D\x0A        var ljs_useCtx = WAVE.isObject(ctx);\x0D\x0A        var ljs_1 = document.createElement(\x27section\x27);\x0D\x0A        var ljs_2 = \x27sect\x27;\x0D\x0A        ljs_1.setAttribute(\x27id\x27, ljs_useCtx ? WAVE.strHTMLTemplate(ljs_2, ctx) : WAVE.strEscapeHTML(ljs_2));\x0D\x0A        var ljs_3 = \x27sect\x27;\x0D\x0A        ljs_1.setAttribute(\x27class\x27, ljs_useCtx ? WAVE.strHTMLTemplate(ljs_3, ctx) : WAVE.strEscapeHTML(ljs_3));\x0D\x0A        var ljs_4 = \x27 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cum sollicitudin interdum,      sollicitudin condimentum montes nulla bibendum aliquam velit? Fermentum mattis aenean nec...      Orci proin litora nec ullamcorper?    \x27;\x0D\x0A        ljs_1.innerText = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_4, ctx) : WAVE.strEscapeHTML(ljs_4);\x0D\x0A        if (typeof(root) !== \x27undefined\x27 \x26\x26 root !== null) {\x0D\x0A        if (WAVE.isString(root))\x0D\x0A        root = WAVE.id(root);\x0D\x0A        if (WAVE.isObject(root))\x0D\x0A        root.appendChild(ljs_1);\x0D\x0A      }\x0D\x0A    ";
ljs_76 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_76, ctx) : ljs_76;
ljs_75.innerText = ljs_76;
ljs_1.appendChild(ljs_75);
if (typeof(root) !== 'undefined' && root !== null) {
if (WAVE.isString(root))
root = WAVE.id(root);
if (WAVE.isObject(root))
root.appendChild(ljs_1);
}
}


function noRoot() {
var ljs_useCtx = WAVE.isObject(ctx);
var ljs_1 = document.createElement('section');
var ljs_2 = "\x0D\x0A      Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cum sollicitudin interdum,\x0D\x0A      sollicitudin condimentum montes nulla bibendum aliquam velit? Fermentum mattis aenean nec...\x0D\x0A      Orci proin litora nec ullamcorper?\x0D\x0A    ";
ljs_2 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_2, ctx) : ljs_2;
ljs_1.innerText = ljs_2;
var ljs_3 = "sect";
ljs_3 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_3, ctx) : ljs_3;
ljs_1.setAttribute('id', ljs_3);
var ljs_4 = "sect";
ljs_4 = ljs_useCtx ? WAVE.strHTMLTemplate(ljs_4, ctx) : ljs_4;
ljs_1.setAttribute('class', ljs_4);
if (typeof(root) !== 'undefined' && root !== null) {
if (WAVE.isString(root))
root = WAVE.id(root);
if (WAVE.isObject(root))
root.appendChild(ljs_1);
}
}