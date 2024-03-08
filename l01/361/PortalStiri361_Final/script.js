document.addEventListener('DOMContentLoaded', () => {
    document.getElementById("search-form").addEventListener('submit', (e) => {
        const data = new FormData(e.target);
        alert(data.get('search'))
        e.preventDefault();
    });
});