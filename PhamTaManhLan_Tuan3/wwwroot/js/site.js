<script>
    document.getElementById("togglePassword").addEventListener("click", function () {
        var passwordField = document.getElementById("password");
    var type = passwordField.type === "password" ? "text" : "password";
    passwordField.type = type;
    });
</script>
