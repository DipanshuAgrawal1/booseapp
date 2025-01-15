namespace mainweb.wwwroot.js {
    /// <summary>
    /// Script for handling canvas interactions like drawing, erasing, and saving images.
    /// </summary>
    public class Script {
        // script.js

        // Getting the canvas element and its context for drawing
        let canvas = document.getElementById("myCanvas");
    let ctx = canvas.getContext("2d");

    // State variables for drawing modes and positions
    let isDrawing = false;
    let isCircleMode = false;
    let isEraserMode = false;
    let lastX = 0;
    let lastY = 0;
    let isSoundPlaying = false;

    // Event listeners for canvas interactions (mousedown, mousemove, mouseup, mouseout)
    canvas.addEventListener("mousedown", startDrawing);
    canvas.addEventListener("mousemove", draw);
    canvas.addEventListener("mouseup", stopDrawing);
    canvas.addEventListener("mouseout", stopDrawing);

    /// <summary>
    /// Initializes drawing on mouse down. Sets the start coordinates.
    /// </summary>
    function startDrawing(e) {
        isDrawing = true;
        lastX = e.offsetX;
        lastY = e.offsetY;
    }

    /// <summary>
    /// Handles drawing or erasing on mouse move based on the current mode (pen or eraser).
    /// </summary>
    function draw(e) {
        if (!isDrawing) return; // Don't draw if not in drawing mode

        ctx.beginPath();
        ctx.moveTo(lastX, lastY);
        ctx.lineTo(e.offsetX, e.offsetY);
        ctx.strokeStyle = isEraserMode ? "#FFFFFF" : "#000000"; // Choose color based on mode
        ctx.lineWidth = isEraserMode ? 20 : 2; // Choose line width based on mode (eraser size or pen size)
        ctx.stroke();

        lastX = e.offsetX;
        lastY = e.offsetY;
    }

    /// <summary>
    /// Stops the drawing process when mouse is released or leaves the canvas.
    /// </summary>
    function stopDrawing() {
        isDrawing = false;
    }

    /// <summary>
    /// Switches the tool to pen mode, disabling other modes.
    /// </summary>
    function togglePen() {
        isCircleMode = false;
        isEraserMode = false;
    }

    /// <summary>
    /// Switches the tool to circle drawing mode, disabling other modes.
    /// </summary>
    function toggleCircle() {
        isCircleMode = true;
        isEraserMode = false;
    }

    /// <summary>
    /// Switches the tool to eraser mode, disabling other modes.
    /// </summary>
    function toggleEraser() {
        isCircleMode = false;
        isEraserMode = true;
    }

    /// <summary>
    /// Toggles sound on or off. Can be expanded to play background sound or audio.
    /// </summary>
    function toggleSound() {
        if (isSoundPlaying) {
            // Stop the sound
            isSoundPlaying = false;
        } else {
            // Play the sound (for example, using an audio element or background music)
            isSoundPlaying = true;
        }
    }

    /// <summary>
    /// Saves the current canvas as an image file.
    /// </summary>
    function saveImage() {
        let dataUrl = canvas.toDataURL(); // Convert canvas content to image URL
        let a = document.createElement("a"); // Create a link element
        a.href = dataUrl;
        a.download = "canvas_image.png"; // Set the file name
        a.click(); // Trigger the download
    }

    /// <summary>
    /// Placeholder function for loading an image onto the canvas.
    /// </summary>
    function loadImage() {
        // You can implement a file input for the user to load an image and draw on it
        alert("Load image functionality coming soon!");
    }

    /// <summary>
    /// Clears the canvas and resets it to a blank state.
    /// </summary>
    function resetCanvas() {
        ctx.clearRect(0, 0, canvas.width, canvas.height); // Clear the entire canvas
        alert("Canvas has been reset!");
    }
}
}
