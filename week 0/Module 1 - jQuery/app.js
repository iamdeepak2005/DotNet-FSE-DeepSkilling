// jquery script to handle interactions
// deepa nair - training assignments

$(document).ready(function() {
    console.log("jquery loaded. starting bindings...");

    // adjust banner borders dynamically
    $("#welcomeBanner").css({
        "border-color": "#818cf8",
        "border-width": "2px"
    });

    // append notice dynamically
    $("#welcome").append("<p style='color:#a7f3d0;'>[Active]: jQuery is modifying layout.</p>");

    // click handler to fade paragraph text
    $(".gallery-item").on("click", function() {
        $(this).toggleClass("highlight-border");
        $(this).find("p").fadeToggle(200);
    });

    // button hover scale
    $("button").hover(
        function() { $(this).css("transform", "scale(1.05)"); },
        function() { $(this).css("transform", "scale(1.0)"); }
    );

    // ajax data loader
    $("#formConfirmation").on("dblclick", function() {
        const text = $(this);
        text.text("Calling api...").css("color", "#facc15");

        $.ajax({
            url: "https://jsonplaceholder.typicode.com/posts/1",
            method: "GET"
        }).done(function(data) {
            text.text("Verified ID: " + data.id + ". Info: " + data.title.substring(0, 30)).css("color", "#10b981");
        }).fail(function() {
            text.text("Failed to load details.").css("color", "#ef4444");
        });
    });
});