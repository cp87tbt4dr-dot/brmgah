import OpenAI from "openai";

const client = new OpenAI({
  apiKey: process.env.OPENAI_API_KEY
});

export default async (req, res) => {
  const body = JSON.parse(req.body);
  const message = body.message;

  const response = await client.chat.completions.create({
    model: "gpt-4o-mini",
    messages: [{ role: "user", content: message }]
  });

  res.status(200).json({
    reply: response.choices[0].message.content
  });
};
