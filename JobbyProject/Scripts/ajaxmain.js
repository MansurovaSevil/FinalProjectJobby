$(document).on("click", "#btnSubmit", function () {
    var postId = $(this).val();
    var description = $("#commentDes").val();
    console.log(postId);
    debugger
    
        $("#errorMsg").css("display", "none")

        
        $.ajax({
            type: "Post",
            url: "/Ajax/CommentList",
            dataType: "html",
            data: { description: description, postId: postId },
            success: function (res) {
                $("#comments").append(res);

                //$("#commentDes").val("")
                if (res == 0) {
                    document.location.href = "/User/Login";
                }
                //if (res != "fail") {

                   

                //}


            }

        })

    

   

})

