import React, { useState } from 'react';
import ColorSwatch from './ColorSwatch';
import './PaletteForm.css';

const PaletteForm = () => {
  const [prompt, setPrompt] = useState('');
  const [colors, setColors] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError('');
    setColors([]);

    try {
      const response = await fetch('/api/palette', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ prompt }),
      });

      if (!response.ok) {
        const errText = await response.text();
        throw new Error(errText || 'Unknown error');
      }

      const data = await response.json();
      setColors(data.colors);
    } catch (err) {
      setError(err.message || 'Something went wrong.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="palette-container">
      <h1 className="palette-title">Gemini Palette Generator 🎨</h1>
      <form onSubmit={handleSubmit} className="palette-form">
        <input
          type="text"
          value={prompt}
          onChange={(e) => setPrompt(e.target.value)}
          placeholder="Describe your color palette."
          className="palette-input"
          required
        />
        <button type="submit" className="palette-button">
          Generate
        </button>
      </form>

      {loading && <p>Generating palette...</p>}
      {error && <p style={{ color: 'red' }}>{error}</p>}

      <div className="palette-grid">
        {colors.map((color) => (
          <ColorSwatch key={color} color={color} />
        ))}
      </div>
    </div>
  );
};

export default PaletteForm;
