(() => {
    'use strict';

    const getStoredTheme = () => localStorage.getItem('theme');
    const setStoredTheme = theme => localStorage.setItem('theme', theme);

    const getPreferredTheme = () => {
        const storedTheme = getStoredTheme();
        if (storedTheme) return storedTheme;
        return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
    };

    const setTheme = theme => {
        if (theme === 'auto') {
            const autoTheme = window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
            document.documentElement.setAttribute('data-bs-theme', autoTheme);
        } else {
            document.documentElement.setAttribute('data-bs-theme', theme);
        }
    };

    const syncToggleInput = theme => {
        const toggle = document.getElementById('themeToggle');
        if (toggle) {
            toggle.checked = theme === 'dark';
        }
    };

    const initThemeToggle = () => {
        const currentTheme = getStoredTheme() || document.documentElement.getAttribute('data-bs-theme') || 'light';
        setTheme(currentTheme);
        syncToggleInput(currentTheme);

        const toggle = document.getElementById('themeToggle');
        if (toggle) {
            toggle.addEventListener('change', () => {
                const newTheme = toggle.checked ? 'dark' : 'light';
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
    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', () => {
        const storedTheme = getStoredTheme();
        if (storedTheme === 'auto' || !storedTheme) {
            setTheme(getPreferredTheme());
            syncToggleInput(getPreferredTheme());
        }
    });
})();
