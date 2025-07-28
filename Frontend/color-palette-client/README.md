README – Gemini Color Palette Generator
# 🎨 Gemini Color Palette Generator

Welcome to the **Gemini Color Palette Generator** — a full-stack application that generates beautiful, modern color palettes based on your creative prompt.

Powered by the **Gemini API**, this tool translates your words into visual color inspiration by returning five unique hex colors tailored to your input.

---

## ✨ Features

- 🔮 Generate custom palettes from natural language prompts  
- 🎨 Displays each color with a swatch and its hex code  
- 📋 Click to copy hex codes to clipboard  
- 💬 Clean, modern UI with responsive design  
- ⚡ Powered by Gemini AI API  

---

## 🚀 Demo

![App Demo Screenshot](screenshot.png)

*Prompt: “sunset over the ocean” → beautiful sunset palette colors*

---

## 🛠️ Tech Stack

**Frontend**
- React (Functional Components + Hooks)
- CSS Grid / Flexbox
- Modern, responsive styling

**Backend**
- Node.js + Express
- Gemini API integration (via REST)

---

## 📦 Installation

1. **Clone the repo**

```bash
git clone https://github.com/your-username/gemini-palette-generator.git
cd gemini-palette-generator
```

2. **Install dependencies**

```bash
# For client
cd client
npm install

# For server
cd ../server
npm install
```

3. **Set up environment variables**

In the `/server` directory, create a `.env` file:

```env
GEMINI_API_KEY=your_gemini_api_key_here
```

4. **Run the app**

```bash
# In the server folder
npm run dev

# In the client folder
npm start
```

---

## 🧠 How It Works

1. User enters a descriptive prompt (e.g., "vintage bookstore vibes").  
2. The prompt is sent to the backend, which makes a POST request to the Gemini API.  
3. Gemini responds with 5 hex color codes.  
4. The frontend renders each hex code as a color swatch.  

---

## 📁 Folder Structure

```
/client
  /components
    - PaletteForm.js
    - ColorSwatch.js
  /styles
    - PaletteForm.css
    - ColorSwatch.css

/server
  - index.js
  - routes/palette.js
```

---

## 🙌 Future Enhancements

- 💾 Save palettes and prompts  
- 🔁 Display recent palettes  
- 🌚 Dark mode  
- 🖼 Export palette as image  
- 🏷️ Auto-generate palette names  

---

## 👩‍💻 Author

Built with ❤️ by [Nikki Schiewer](https://github.com/NicoleSchiewer)
