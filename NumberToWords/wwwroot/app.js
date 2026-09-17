$("#converterForm").on("submit", async function (event) {
    event.preventDefault();

    const maxAmountAllowed = 999_999_999_999.99;
    const genericErrorMessage = "An error occurred while processing your request. Please try again.";
    const numberInputValue = $("#numberInput").val().trim();
    const numberInput = Number(numberInputValue);
    const isValidMoneyAmount = /^\d+(\.\d{1,2})?$/.test(numberInputValue);

    if (numberInput < 0 || numberInput > maxAmountAllowed || !isValidMoneyAmount) {
        const invalidErrorMessage = "Please enter a valid number with no more than 2 decimal places and within the range of 0 to 999,999,999,999.99.";
        showNotfificationMessage(invalidErrorMessage, false);
        return;
    }

    try {
        const response = await fetch("/convertNumberToWords", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ number: numberInput })
        });

        const data = await response.json();

        if (!response.ok || data.errorMessage) {
            const errorMessage = data.errorMessage || genericErrorMessage;
            showNotfificationMessage(errorMessage, false);
            return;
        }

        showNotfificationMessage(data.words, true);
    } catch {
        showNotfificationMessage(genericErrorMessage, false);
    }
});

function showNotfificationMessage(message, isValid) {
    const alertClass = isValid ? "alert-light" : "alert-danger";
    $("#notificationMessage").removeClass("alert-light alert-danger d-none")
        .addClass(alertClass)
        .text(message)
        .show();
}
