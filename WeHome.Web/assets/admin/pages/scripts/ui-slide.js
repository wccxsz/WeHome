
//涓荤珯杞挱鍥�
//2015-03-20

$(function () {

    var Slide_boxWidth = $("#UISlide").width();//鑾峰彇骞荤伅鐗囧閮╠iv瀹藉害
    var Slide_boxHeight = $("#UISlide").height();//鑾峰彇骞荤伅鐗囧閮╠iv楂樺害
    var Slide_LiWidth = $("#UISlide").children("ul").children("li").eq(0).width();//鑾峰彇骞荤伅鐗嘗i鐨勫搴�
    var Slide_liNubr = $("#UISlide").find('li').length;//鑾峰彇骞荤伅鐗嘗i鐨勬暟閲�
    var Slide_Speed = 3500;//婊氬姩閫熷害

    if (Slide_liNubr < 3) {
        return false;   //鍥剧墖灏忎簬涓夊紶涓嶆墽琛�
    }

    for (var i = 0; i < parseInt(Slide_liNubr) ; i++) {
        if (i == parseInt(Slide_liNubr - 1)) {
            $("#UISlide").children("ul").children("li").eq(i).css("left", -Slide_LiWidth);
        } else {
            $("#UISlide").children("ul").children("li").eq(i).css("left", i * Slide_LiWidth);//鍒濆鍖朙i浣嶇疆
        }
    }
    var Slide_Run = setInterval(Slide_Next, Slide_Speed)//璁剧疆婊氬姩鍣�

    function Slide_Next() {
        for (var k = 0; k < parseInt(Slide_liNubr) ; k++) {
            if (parseInt($("#UISlide").children("ul").children("li").eq(k).css("left")) == -Slide_LiWidth)//鍒ゆ柇LI鏄惁鏈変綅绉诲埌0锛岄槻姝㈠悓鏃跺娆＄偣鍑诲嚭閿�
            {

                var Slide_liSeat = 0;//浣嶇疆鍙傛暟褰掗浂
                for (var j = 0; j < parseInt(Slide_liNubr) ; j++) {
                    if (parseInt($("#UISlide").children("ul").children("li").eq(j).css("left")) == -Slide_LiWidth) {//鍒ゆ柇鏄惁绗竴涓�

                        $("#UISlide").children("ul").children("li").eq(j).css("left", Slide_LiWidth * (Slide_liNubr - 2));//绗竴涓洖鍒版渶鍚庝竴涓�

                    } else {

                        Slide_liSeat = parseInt($("#UISlide").children("ul").children("li").eq(j).css("left")) - Slide_LiWidth;//鑾峰彇浣嶇Щ浣嶇疆
                        $("#UISlide").children("ul").children("li").eq(j).animate({ left: Slide_liSeat }, "slow");//杩涜浣嶇Щ鍔ㄧ敾

                    }
                }

            }
        }
    }

    function Slide_Last() {
        for (var k = 0; k < parseInt(Slide_liNubr) ; k++) {
            if (parseInt($("#UISlide").children("ul").children("li").eq(k).css("left")) == 0)//鍒ゆ柇LI鏄惁鏈変綅绉诲埌0锛岄槻姝㈠悓鏃跺娆＄偣鍑诲嚭閿�
            {

                var Slide_liSeat = 0;//浣嶇疆鍙傛暟褰掗浂
                for (var j = 0; j < parseInt(Slide_liNubr) ; j++) {
                    if (parseInt($("#UISlide").children("ul").children("li").eq(j).css("left")) == Slide_LiWidth * (Slide_liNubr - 2)) {//鍒ゆ柇鏄惁绗竴涓�

                        $("#UISlide").children("ul").children("li").eq(j).css("left", -Slide_LiWidth);//绗竴涓洖鍒版渶鍚庝竴涓�

                    } else {

                        Slide_liSeat = parseInt($("#UISlide").children("ul").children("li").eq(j).css("left")) + Slide_LiWidth;//鑾峰彇浣嶇Щ浣嶇疆
                        $("#UISlide").children("ul").children("li").eq(j).animate({ left: Slide_liSeat }, "slow");//杩涜浣嶇Щ鍔ㄧ敾

                    }
                }

            }
        }
    }

    $(".arrows").mouseenter(function () { $(this).find("i").show(); }); //榧犳爣婊戣繃鏄剧ず绠ご
    $(".arrows").mouseleave(function () { $(this).find("i").hide(); });
    $("#UISlide .next").click(Slide_Next);//涓嬩竴寮犳寜閽�
    $("#UISlide .prev").click(Slide_Last);//涓婁竴寮犳寜閽�
    $("#UISlide").mouseenter(function () { clearInterval(Slide_Run) });//榧犳爣鍦ㄥ够鐏墖涓婏紝鍋滄婊氬姩
    $("#UISlide").mouseleave(function () { Slide_Run = setInterval(Slide_Next, Slide_Speed) })//榧犳爣涓嶅湪骞荤伅鍝︿笂锛屽紑濮嬫粴鍔�
})