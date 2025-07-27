import React from 'react';

const ColorSwatch = ({ color }) => {
  return (
    <div className="color-swatch">
      <div
        className="color-box"
        style={{ backgroundColor: color }}
      />
      <p>{color}</p>
    </div>
  );
};

export default ColorSwatch;
