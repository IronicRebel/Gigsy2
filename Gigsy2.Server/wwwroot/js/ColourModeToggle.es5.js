'use strict';

(function () {
    'use strict';

    var getStoredTheme = function getStoredTheme() {
        return localStorage.getItem('theme');
    };
    var setStoredTheme = function setStoredTheme(theme) {
        return localStorage.setItem('theme', theme);
    };

    var getPreferredTheme = function getPreferredTheme() {
        var storedTheme = getStoredTheme();
        if (storedTheme) return storedTheme;
        return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    };

    var setTheme = function setTheme(theme) {
        if (theme === 'auto') {
            var autoTheme = window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
            document.documentElement.setAttribute('data-bs-theme', autoTheme);
        } else {
            document.documentElement.setAttribute('data-bs-theme', theme);
        }
    };

    var syncToggleInput = function syncToggleInput(theme) {
        var toggle = document.getElementById('themeToggle');
        if (toggle) {
            toggle.checked = theme === 'dark';
        }
    };

    var initThemeToggle = function initThemeToggle() {
        var currentTheme = getStoredTheme() || document.documentElement.getAttribute('data-bs-theme') || 'light';
        setTheme(currentTheme);
        syncToggleInput(currentTheme);

        var toggle = document.getElementById('themeToggle');
        if (toggle) {
            toggle.addEventListener('change', function () {
                var newTheme = toggle.checked ? 'dark' : 'light';
                setStoredTheme(newTheme);
                setTheme(newTheme);
            });
        }
    };

    // Apply theme on initial load
    document.addEventListener('DOMContentLoaded', initThemeToggle);

    // Re-sync toggle on Blazor navigation
    document.addEventListener('blazor:navigation', initThemeToggle);

    // Auto mode listener (optional)
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', function () {
        var storedTheme = getStoredTheme();
        if (storedTheme === 'auto' || !storedTheme) {
            setTheme(getPreferredTheme());
            syncToggleInput(getPreferredTheme());
        }
    });
})();

