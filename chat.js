import OpenAI from "openai";

const client = new OpenAI({
  apiKey: process.env.OPENAI_API_KEY
});

export default async (req, res) => {
  try {
    const body = JSON.parse(req.body || "{}");
    const message = body.message;

    if (!message) {
      return res.status(400).json({ reply: "اكتب رسالة أول" });
    }

    const response = await client.chat.completions.create({
      model: "gpt-4o-mini",
      messages: [
        { role: "system", content: "أنت مساعد ذكي تتكلم عربي بشكل بسيط ومفيد" },
        { role: "user", content: message }
      ]
    });

    res.status(200).json({
      reply: response.choices[0].message.content
    });

  } catch (err) {
    res.status(500).json({
      reply: "صار خطأ في السيرفر"
    });
  }
};
