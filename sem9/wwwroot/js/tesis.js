$(document).ready(function () {
  const btns = document.querySelectorAll("#btnDeshabilitar");

  const table = document.querySelector("#tesistable");

  function asignarEventos() {
    const btns = document.querySelectorAll("#btnDeshabilitar");

    btns.forEach((btn) => {
      btn.addEventListener("click", async (e) => {
        const id = e.target.getAttribute("data-id");
        const res = await fetch(`/Tesis/UpdateState/${id}`, {
          method: "PUT",
        });

        if (res.ok) {
          const data = await res.text();
          table.innerHTML = data;
          asignarEventos();
        }
      });
    });
  }
  asignarEventos();
});
