window.showToast = function (whitchButton) {
    const targetDiv = document.getElementById("externalInput");

    switch (whitchButton) {
        case "add":
            if (targetDiv) {
                targetDiv.innerText = "Zadanie zostało dodane";
            }
            break;

        case "delete":
            if (targetDiv) {
                targetDiv.innerText = "Zadanie zostało usunięte";
            }
    }

    const toastLiveExample = document.getElementById('liveToast');
    const toastBootStrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample);
    toastBootStrap.show();
}