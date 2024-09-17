function addStylesheet(cssUrl) {
    // Create a link element
    var cssLink = document.createElement("link");
    cssLink.rel = "stylesheet";
    cssLink.href = cssUrl; // Use the provided CSS URL

    // Append the link element to the placeholder
    document.getElementById("dynamic-css").appendChild(cssLink);
}
