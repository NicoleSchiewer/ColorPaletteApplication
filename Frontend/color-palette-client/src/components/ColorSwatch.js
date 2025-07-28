import React from 'react';
import './ColorSwatch.css'; // <-- make sure this is here

const ColorSwatch = ({ color }) => {
  return (
    <div className="color-swatch">
      <div
        className="color-box"
        style={{ backgroundColor: color }}
      />
      <p className="hex-label">{color}</p>
    </div>
  );
};

export default ColorSwatch;
